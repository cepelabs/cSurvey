<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScaleRules
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScaleRules))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.lv = New System.Windows.Forms.ListView()
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.tabInfo = New System.Windows.Forms.TabControl()
        Me.tabInfoMain = New System.Windows.Forms.TabPage()
        Me.lblScaleWarning = New System.Windows.Forms.Label()
        Me.picScaleWarning = New System.Windows.Forms.PictureBox()
        Me.txtScale = New System.Windows.Forms.NumericUpDown()
        Me.lblScale = New System.Windows.Forms.Label()
        Me.tanInfoCategories = New System.Windows.Forms.TabPage()
        Me.grdCategoriesVisibility = New cSurveyPC.cGrid()
        Me.colCategoryIndex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategoryVisibility = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tabInfODesign = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBaseMediumLinesScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.txtBaseUltraLightLinesScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.txtBaseLightLinesScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.txtBaseHeavyLinesScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblBaseLinesScaleFactor = New System.Windows.Forms.Label()
        Me.txtBaseLineWidthScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblBaseLineWidthScaleFactor = New System.Windows.Forms.Label()
        Me.frrmDesign = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblDesignCrossSectionTextScaleFactor = New System.Windows.Forms.Label()
        Me.txtDesignCrossSectionTextScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblDesignCrossSectionMarkerTextScaleFactor = New System.Windows.Forms.Label()
        Me.txtDesignCrossSectionMarkerTextScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.txtDesignCrossSectionMarkerArrowScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignCrossSectionMarkerArrowScaleFactor = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.txtDesignExtraScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignExtraTextScaleFactor = New System.Windows.Forms.Label()
        Me.lblDesignExtraScaleFactor = New System.Windows.Forms.Label()
        Me.txtDesignExtraTextScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignTextureScale = New System.Windows.Forms.Label()
        Me.txtDesignTextureScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.txtDesignTextFont = New System.Windows.Forms.TextBox()
        Me.cmdDesignTextFont = New System.Windows.Forms.Button()
        Me.lblDesignTextFont = New System.Windows.Forms.Label()
        Me.lblDesignSoilScale = New System.Windows.Forms.Label()
        Me.txtDesignSoilScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignClipartScaleFactor = New System.Windows.Forms.Label()
        Me.txtDesignClipartScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignTextScaleFactor = New System.Windows.Forms.Label()
        Me.txtDesignTextScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignSignScaleFactor = New System.Windows.Forms.Label()
        Me.txtDesignSignScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblDesignTerrainLevelScaleFactor = New System.Windows.Forms.Label()
        Me.txtDesignTerrainLevelScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.tabInfoPlot = New System.Windows.Forms.TabPage()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.txtPlotNoteTextFont = New System.Windows.Forms.TextBox()
        Me.cmdPlotNoteTextFont = New System.Windows.Forms.Button()
        Me.lblPlotNoteTextFont = New System.Windows.Forms.Label()
        Me.cmdPlotNoteTextColor = New System.Windows.Forms.Button()
        Me.lblPlotNoteTextColor = New System.Windows.Forms.Label()
        Me.picPlotNoteTextColor = New System.Windows.Forms.PictureBox()
        Me.txtPlotNoteTextScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotNoteTextScaleFactor = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.lblPlotSplaySelectedPenWidth = New System.Windows.Forms.Label()
        Me.txtPlotSplaySelectedPenWidth = New System.Windows.Forms.NumericUpDown()
        Me.txtPlotSplayPenWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotSplayPenWidth = New System.Windows.Forms.Label()
        Me.cboPlotSplayPenStyle = New System.Windows.Forms.ComboBox()
        Me.lblPlotSplayPenStyle = New System.Windows.Forms.Label()
        Me.frmPlotLRUD = New System.Windows.Forms.GroupBox()
        Me.lblPlotLRUDSelectedPenWidth = New System.Windows.Forms.Label()
        Me.txtPlotLRUDSelectedPenWidth = New System.Windows.Forms.NumericUpDown()
        Me.txtPlotLRUDPenWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotLRUDPenWidth = New System.Windows.Forms.Label()
        Me.cboPlotLRUDPenStyle = New System.Windows.Forms.ComboBox()
        Me.lblPlotLRUDPenStyle = New System.Windows.Forms.Label()
        Me.frmPlotTranslationLine = New System.Windows.Forms.GroupBox()
        Me.cmdPlotTranslationLinePenColor = New System.Windows.Forms.Button()
        Me.lblPlotTranslationLinePenColor = New System.Windows.Forms.Label()
        Me.picPlotTranslationLinePenColor = New System.Windows.Forms.PictureBox()
        Me.txtPlotTranslationLinePenWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotTranslationLinePenSize = New System.Windows.Forms.Label()
        Me.cboPlotTranslationLinePenStyle = New System.Windows.Forms.ComboBox()
        Me.lblPlotTranslationLinePenStyle = New System.Windows.Forms.Label()
        Me.frmPlotPoint = New System.Windows.Forms.GroupBox()
        Me.txtPlotTextFont = New System.Windows.Forms.TextBox()
        Me.cmdPlotTextFont = New System.Windows.Forms.Button()
        Me.cmdPlotPointColor = New System.Windows.Forms.Button()
        Me.lblPlotTextFont = New System.Windows.Forms.Label()
        Me.lblPlotPointColor = New System.Windows.Forms.Label()
        Me.cmdPlotTextColor = New System.Windows.Forms.Button()
        Me.picPlotPointColor = New System.Windows.Forms.PictureBox()
        Me.lblPlotTextColor = New System.Windows.Forms.Label()
        Me.cboPlotPointSymbol = New System.Windows.Forms.ComboBox()
        Me.picPlotTextColor = New System.Windows.Forms.PictureBox()
        Me.txtPlotSelectedPointSize = New System.Windows.Forms.NumericUpDown()
        Me.txtPlotTextScaleFactor = New System.Windows.Forms.NumericUpDown()
        Me.txtPlotPointSize = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotTextScaleFactor = New System.Windows.Forms.Label()
        Me.lblPlotSelectedPointSize = New System.Windows.Forms.Label()
        Me.lblPlotPointSize = New System.Windows.Forms.Label()
        Me.lblPlotPointSymbol = New System.Windows.Forms.Label()
        Me.frmPlotPen = New System.Windows.Forms.GroupBox()
        Me.cmdPlotPenColor = New System.Windows.Forms.Button()
        Me.lblPlotPenColor = New System.Windows.Forms.Label()
        Me.picPlotPenColor = New System.Windows.Forms.PictureBox()
        Me.txtPlotPenWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotPenWidth = New System.Windows.Forms.Label()
        Me.lblPlotSelectedPenWidth = New System.Windows.Forms.Label()
        Me.cboPlotPenStyle = New System.Windows.Forms.ComboBox()
        Me.txtPlotSelectedPenWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblPlotPenStyle = New System.Windows.Forms.Label()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.lblAddScale = New System.Windows.Forms.ToolStripLabel()
        Me.txtAddScale = New System.Windows.Forms.ToolStripTextBox()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnAddAsCopy = New System.Windows.Forms.ToolStripButton()
        Me.sep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRemove = New System.Windows.Forms.ToolStripButton()
        Me.btnRemoveAll = New System.Windows.Forms.ToolStripButton()
        Me.sep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnClear = New System.Windows.Forms.ToolStripButton()
        Me.sep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.btnImport = New System.Windows.Forms.ToolStripButton()
        Me.tabInfo.SuspendLayout()
        Me.tabInfoMain.SuspendLayout()
        CType(Me.picScaleWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tanInfoCategories.SuspendLayout()
        CType(Me.grdCategoriesVisibility, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInfODesign.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtBaseMediumLinesScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaseUltraLightLinesScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaseLightLinesScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaseHeavyLinesScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaseLineWidthScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frrmDesign.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtDesignCrossSectionTextScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtDesignCrossSectionMarkerTextScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignCrossSectionMarkerArrowScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.txtDesignExtraScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignExtraTextScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignTextureScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignSoilScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignClipartScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignTextScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignSignScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDesignTerrainLevelScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabInfoPlot.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.picPlotNoteTextColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotNoteTextScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.txtPlotSplaySelectedPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotSplayPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmPlotLRUD.SuspendLayout()
        CType(Me.txtPlotLRUDSelectedPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotLRUDPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmPlotTranslationLine.SuspendLayout()
        CType(Me.picPlotTranslationLinePenColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotTranslationLinePenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmPlotPoint.SuspendLayout()
        CType(Me.picPlotPointColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPlotTextColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotSelectedPointSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotTextScaleFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotPointSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.frmPlotPen.SuspendLayout()
        CType(Me.picPlotPenColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPlotSelectedPenWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'lv
        '
        resources.ApplyResources(Me.lv, "lv")
        Me.lv.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.lv.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lv.HideSelection = False
        Me.lv.LargeImageList = Me.iml
        Me.lv.MultiSelect = False
        Me.lv.Name = "lv"
        Me.lv.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lv.UseCompatibleStateImageBehavior = False
        '
        'iml
        '
        Me.iml.ImageStream = CType(resources.GetObject("iml.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        Me.iml.Images.SetKeyName(0, "impostazioni")
        '
        'tabInfo
        '
        resources.ApplyResources(Me.tabInfo, "tabInfo")
        Me.tabInfo.Controls.Add(Me.tabInfoMain)
        Me.tabInfo.Controls.Add(Me.tanInfoCategories)
        Me.tabInfo.Controls.Add(Me.tabInfODesign)
        Me.tabInfo.Controls.Add(Me.tabInfoPlot)
        Me.tabInfo.Name = "tabInfo"
        Me.tabInfo.SelectedIndex = 0
        '
        'tabInfoMain
        '
        Me.tabInfoMain.Controls.Add(Me.lblScaleWarning)
        Me.tabInfoMain.Controls.Add(Me.picScaleWarning)
        Me.tabInfoMain.Controls.Add(Me.txtScale)
        Me.tabInfoMain.Controls.Add(Me.lblScale)
        resources.ApplyResources(Me.tabInfoMain, "tabInfoMain")
        Me.tabInfoMain.Name = "tabInfoMain"
        Me.tabInfoMain.UseVisualStyleBackColor = True
        '
        'lblScaleWarning
        '
        resources.ApplyResources(Me.lblScaleWarning, "lblScaleWarning")
        Me.lblScaleWarning.Name = "lblScaleWarning"
        '
        'picScaleWarning
        '
        resources.ApplyResources(Me.picScaleWarning, "picScaleWarning")
        Me.picScaleWarning.Name = "picScaleWarning"
        Me.picScaleWarning.TabStop = False
        '
        'txtScale
        '
        Me.txtScale.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        resources.ApplyResources(Me.txtScale, "txtScale")
        Me.txtScale.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtScale.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'lblScale
        '
        resources.ApplyResources(Me.lblScale, "lblScale")
        Me.lblScale.Name = "lblScale"
        '
        'tanInfoCategories
        '
        Me.tanInfoCategories.Controls.Add(Me.grdCategoriesVisibility)
        resources.ApplyResources(Me.tanInfoCategories, "tanInfoCategories")
        Me.tanInfoCategories.Name = "tanInfoCategories"
        Me.tanInfoCategories.UseVisualStyleBackColor = True
        '
        'grdCategoriesVisibility
        '
        Me.grdCategoriesVisibility.AllowUserToAddRows = False
        Me.grdCategoriesVisibility.AllowUserToDeleteRows = False
        Me.grdCategoriesVisibility.AllowUserToResizeRows = False
        Me.grdCategoriesVisibility.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdCategoriesVisibility.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdCategoriesVisibility.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCategoryIndex, Me.colCategoryName, Me.colCategoryVisibility})
        resources.ApplyResources(Me.grdCategoriesVisibility, "grdCategoriesVisibility")
        Me.grdCategoriesVisibility.Name = "grdCategoriesVisibility"
        Me.grdCategoriesVisibility.RowHeadersVisible = False
        Me.grdCategoriesVisibility.ShowEditingIcon = False
        '
        'colCategoryIndex
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.colCategoryIndex.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.colCategoryIndex, "colCategoryIndex")
        Me.colCategoryIndex.Name = "colCategoryIndex"
        Me.colCategoryIndex.ReadOnly = True
        '
        'colCategoryName
        '
        resources.ApplyResources(Me.colCategoryName, "colCategoryName")
        Me.colCategoryName.Name = "colCategoryName"
        Me.colCategoryName.ReadOnly = True
        '
        'colCategoryVisibility
        '
        resources.ApplyResources(Me.colCategoryVisibility, "colCategoryVisibility")
        Me.colCategoryVisibility.Name = "colCategoryVisibility"
        '
        'tabInfODesign
        '
        resources.ApplyResources(Me.tabInfODesign, "tabInfODesign")
        Me.tabInfODesign.Controls.Add(Me.GroupBox1)
        Me.tabInfODesign.Controls.Add(Me.frrmDesign)
        Me.tabInfODesign.Name = "tabInfODesign"
        Me.tabInfODesign.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtBaseMediumLinesScaleFactor)
        Me.GroupBox1.Controls.Add(Me.txtBaseUltraLightLinesScaleFactor)
        Me.GroupBox1.Controls.Add(Me.txtBaseLightLinesScaleFactor)
        Me.GroupBox1.Controls.Add(Me.txtBaseHeavyLinesScaleFactor)
        Me.GroupBox1.Controls.Add(Me.lblBaseLinesScaleFactor)
        Me.GroupBox1.Controls.Add(Me.txtBaseLineWidthScaleFactor)
        Me.GroupBox1.Controls.Add(Me.lblBaseLineWidthScaleFactor)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        Me.Label8.Tag = "txtBaseUltraLightLinesScaleFactor"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        Me.Label7.Tag = "txtBaseLightLinesScaleFactor"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        Me.Label4.Tag = "txtBaseMediumLinesScaleFactor"
        '
        'txtBaseMediumLinesScaleFactor
        '
        Me.txtBaseMediumLinesScaleFactor.DecimalPlaces = 1
        Me.txtBaseMediumLinesScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtBaseMediumLinesScaleFactor, "txtBaseMediumLinesScaleFactor")
        Me.txtBaseMediumLinesScaleFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtBaseMediumLinesScaleFactor.Name = "txtBaseMediumLinesScaleFactor"
        Me.txtBaseMediumLinesScaleFactor.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'txtBaseUltraLightLinesScaleFactor
        '
        Me.txtBaseUltraLightLinesScaleFactor.DecimalPlaces = 1
        Me.txtBaseUltraLightLinesScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtBaseUltraLightLinesScaleFactor, "txtBaseUltraLightLinesScaleFactor")
        Me.txtBaseUltraLightLinesScaleFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtBaseUltraLightLinesScaleFactor.Name = "txtBaseUltraLightLinesScaleFactor"
        Me.txtBaseUltraLightLinesScaleFactor.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'txtBaseLightLinesScaleFactor
        '
        Me.txtBaseLightLinesScaleFactor.DecimalPlaces = 1
        Me.txtBaseLightLinesScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtBaseLightLinesScaleFactor, "txtBaseLightLinesScaleFactor")
        Me.txtBaseLightLinesScaleFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtBaseLightLinesScaleFactor.Name = "txtBaseLightLinesScaleFactor"
        Me.txtBaseLightLinesScaleFactor.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'txtBaseHeavyLinesScaleFactor
        '
        Me.txtBaseHeavyLinesScaleFactor.DecimalPlaces = 1
        Me.txtBaseHeavyLinesScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        resources.ApplyResources(Me.txtBaseHeavyLinesScaleFactor, "txtBaseHeavyLinesScaleFactor")
        Me.txtBaseHeavyLinesScaleFactor.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.txtBaseHeavyLinesScaleFactor.Name = "txtBaseHeavyLinesScaleFactor"
        Me.txtBaseHeavyLinesScaleFactor.Value = New Decimal(New Integer() {1, 0, 0, 65536})
        '
        'lblBaseLinesScaleFactor
        '
        resources.ApplyResources(Me.lblBaseLinesScaleFactor, "lblBaseLinesScaleFactor")
        Me.lblBaseLinesScaleFactor.Name = "lblBaseLinesScaleFactor"
        Me.lblBaseLinesScaleFactor.Tag = "txtBaseHeavyLinesScaleFactor"
        '
        'txtBaseLineWidthScaleFactor
        '
        Me.txtBaseLineWidthScaleFactor.DecimalPlaces = 4
        Me.txtBaseLineWidthScaleFactor.Increment = New Decimal(New Integer() {5, 0, 0, 262144})
        resources.ApplyResources(Me.txtBaseLineWidthScaleFactor, "txtBaseLineWidthScaleFactor")
        Me.txtBaseLineWidthScaleFactor.Minimum = New Decimal(New Integer() {5, 0, 0, 262144})
        Me.txtBaseLineWidthScaleFactor.Name = "txtBaseLineWidthScaleFactor"
        Me.txtBaseLineWidthScaleFactor.Value = New Decimal(New Integer() {1, 0, 0, 196608})
        '
        'lblBaseLineWidthScaleFactor
        '
        resources.ApplyResources(Me.lblBaseLineWidthScaleFactor, "lblBaseLineWidthScaleFactor")
        Me.lblBaseLineWidthScaleFactor.Name = "lblBaseLineWidthScaleFactor"
        Me.lblBaseLineWidthScaleFactor.Tag = "txtBaseLineWidthScaleFactor"
        '
        'frrmDesign
        '
        Me.frrmDesign.Controls.Add(Me.GroupBox2)
        Me.frrmDesign.Controls.Add(Me.GroupBox10)
        Me.frrmDesign.Controls.Add(Me.lblDesignTextureScale)
        Me.frrmDesign.Controls.Add(Me.txtDesignTextureScaleFactor)
        Me.frrmDesign.Controls.Add(Me.txtDesignTextFont)
        Me.frrmDesign.Controls.Add(Me.cmdDesignTextFont)
        Me.frrmDesign.Controls.Add(Me.lblDesignTextFont)
        Me.frrmDesign.Controls.Add(Me.lblDesignSoilScale)
        Me.frrmDesign.Controls.Add(Me.txtDesignSoilScaleFactor)
        Me.frrmDesign.Controls.Add(Me.lblDesignClipartScaleFactor)
        Me.frrmDesign.Controls.Add(Me.txtDesignClipartScaleFactor)
        Me.frrmDesign.Controls.Add(Me.lblDesignTextScaleFactor)
        Me.frrmDesign.Controls.Add(Me.txtDesignTextScaleFactor)
        Me.frrmDesign.Controls.Add(Me.lblDesignSignScaleFactor)
        Me.frrmDesign.Controls.Add(Me.txtDesignSignScaleFactor)
        Me.frrmDesign.Controls.Add(Me.lblDesignTerrainLevelScaleFactor)
        Me.frrmDesign.Controls.Add(Me.txtDesignTerrainLevelScaleFactor)
        resources.ApplyResources(Me.frrmDesign, "frrmDesign")
        Me.frrmDesign.Name = "frrmDesign"
        Me.frrmDesign.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblDesignCrossSectionTextScaleFactor)
        Me.GroupBox2.Controls.Add(Me.txtDesignCrossSectionTextScaleFactor)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'lblDesignCrossSectionTextScaleFactor
        '
        resources.ApplyResources(Me.lblDesignCrossSectionTextScaleFactor, "lblDesignCrossSectionTextScaleFactor")
        Me.lblDesignCrossSectionTextScaleFactor.Name = "lblDesignCrossSectionTextScaleFactor"
        Me.lblDesignCrossSectionTextScaleFactor.Tag = "txtDesignCrossSectionTextScaleFactor"
        '
        'txtDesignCrossSectionTextScaleFactor
        '
        Me.txtDesignCrossSectionTextScaleFactor.DecimalPlaces = 2
        Me.txtDesignCrossSectionTextScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignCrossSectionTextScaleFactor, "txtDesignCrossSectionTextScaleFactor")
        Me.txtDesignCrossSectionTextScaleFactor.Name = "txtDesignCrossSectionTextScaleFactor"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblDesignCrossSectionMarkerTextScaleFactor)
        Me.GroupBox3.Controls.Add(Me.txtDesignCrossSectionMarkerTextScaleFactor)
        Me.GroupBox3.Controls.Add(Me.txtDesignCrossSectionMarkerArrowScaleFactor)
        Me.GroupBox3.Controls.Add(Me.lblDesignCrossSectionMarkerArrowScaleFactor)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'lblDesignCrossSectionMarkerTextScaleFactor
        '
        resources.ApplyResources(Me.lblDesignCrossSectionMarkerTextScaleFactor, "lblDesignCrossSectionMarkerTextScaleFactor")
        Me.lblDesignCrossSectionMarkerTextScaleFactor.Name = "lblDesignCrossSectionMarkerTextScaleFactor"
        Me.lblDesignCrossSectionMarkerTextScaleFactor.Tag = "txtDesignCrossSectionMarkerTextScaleFactor"
        '
        'txtDesignCrossSectionMarkerTextScaleFactor
        '
        Me.txtDesignCrossSectionMarkerTextScaleFactor.DecimalPlaces = 2
        Me.txtDesignCrossSectionMarkerTextScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignCrossSectionMarkerTextScaleFactor, "txtDesignCrossSectionMarkerTextScaleFactor")
        Me.txtDesignCrossSectionMarkerTextScaleFactor.Name = "txtDesignCrossSectionMarkerTextScaleFactor"
        '
        'txtDesignCrossSectionMarkerArrowScaleFactor
        '
        Me.txtDesignCrossSectionMarkerArrowScaleFactor.DecimalPlaces = 2
        Me.txtDesignCrossSectionMarkerArrowScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignCrossSectionMarkerArrowScaleFactor, "txtDesignCrossSectionMarkerArrowScaleFactor")
        Me.txtDesignCrossSectionMarkerArrowScaleFactor.Name = "txtDesignCrossSectionMarkerArrowScaleFactor"
        '
        'lblDesignCrossSectionMarkerArrowScaleFactor
        '
        resources.ApplyResources(Me.lblDesignCrossSectionMarkerArrowScaleFactor, "lblDesignCrossSectionMarkerArrowScaleFactor")
        Me.lblDesignCrossSectionMarkerArrowScaleFactor.Name = "lblDesignCrossSectionMarkerArrowScaleFactor"
        Me.lblDesignCrossSectionMarkerArrowScaleFactor.Tag = "txtDesignCrossSectionMarkerArrowScaleFactor"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.txtDesignExtraScaleFactor)
        Me.GroupBox10.Controls.Add(Me.lblDesignExtraTextScaleFactor)
        Me.GroupBox10.Controls.Add(Me.lblDesignExtraScaleFactor)
        Me.GroupBox10.Controls.Add(Me.txtDesignExtraTextScaleFactor)
        resources.ApplyResources(Me.GroupBox10, "GroupBox10")
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.TabStop = False
        '
        'txtDesignExtraScaleFactor
        '
        Me.txtDesignExtraScaleFactor.DecimalPlaces = 2
        Me.txtDesignExtraScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignExtraScaleFactor, "txtDesignExtraScaleFactor")
        Me.txtDesignExtraScaleFactor.Name = "txtDesignExtraScaleFactor"
        '
        'lblDesignExtraTextScaleFactor
        '
        resources.ApplyResources(Me.lblDesignExtraTextScaleFactor, "lblDesignExtraTextScaleFactor")
        Me.lblDesignExtraTextScaleFactor.Name = "lblDesignExtraTextScaleFactor"
        Me.lblDesignExtraTextScaleFactor.Tag = "txtDesignExtraTextScaleFactor"
        '
        'lblDesignExtraScaleFactor
        '
        resources.ApplyResources(Me.lblDesignExtraScaleFactor, "lblDesignExtraScaleFactor")
        Me.lblDesignExtraScaleFactor.Name = "lblDesignExtraScaleFactor"
        Me.lblDesignExtraScaleFactor.Tag = "txtDesignExtraScaleFactor"
        '
        'txtDesignExtraTextScaleFactor
        '
        Me.txtDesignExtraTextScaleFactor.DecimalPlaces = 2
        Me.txtDesignExtraTextScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignExtraTextScaleFactor, "txtDesignExtraTextScaleFactor")
        Me.txtDesignExtraTextScaleFactor.Name = "txtDesignExtraTextScaleFactor"
        '
        'lblDesignTextureScale
        '
        resources.ApplyResources(Me.lblDesignTextureScale, "lblDesignTextureScale")
        Me.lblDesignTextureScale.Name = "lblDesignTextureScale"
        Me.lblDesignTextureScale.Tag = "txtDesignTextureScaleFactor"
        '
        'txtDesignTextureScaleFactor
        '
        Me.txtDesignTextureScaleFactor.DecimalPlaces = 2
        Me.txtDesignTextureScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignTextureScaleFactor, "txtDesignTextureScaleFactor")
        Me.txtDesignTextureScaleFactor.Name = "txtDesignTextureScaleFactor"
        '
        'txtDesignTextFont
        '
        resources.ApplyResources(Me.txtDesignTextFont, "txtDesignTextFont")
        Me.txtDesignTextFont.Name = "txtDesignTextFont"
        Me.txtDesignTextFont.ReadOnly = True
        '
        'cmdDesignTextFont
        '
        resources.ApplyResources(Me.cmdDesignTextFont, "cmdDesignTextFont")
        Me.cmdDesignTextFont.Name = "cmdDesignTextFont"
        Me.cmdDesignTextFont.UseVisualStyleBackColor = True
        '
        'lblDesignTextFont
        '
        resources.ApplyResources(Me.lblDesignTextFont, "lblDesignTextFont")
        Me.lblDesignTextFont.Name = "lblDesignTextFont"
        Me.lblDesignTextFont.Tag = "cmdDesignTextFont;txtDesignTextFont"
        '
        'lblDesignSoilScale
        '
        resources.ApplyResources(Me.lblDesignSoilScale, "lblDesignSoilScale")
        Me.lblDesignSoilScale.Name = "lblDesignSoilScale"
        Me.lblDesignSoilScale.Tag = "txtDesignSoilScaleFactor"
        '
        'txtDesignSoilScaleFactor
        '
        Me.txtDesignSoilScaleFactor.DecimalPlaces = 2
        Me.txtDesignSoilScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignSoilScaleFactor, "txtDesignSoilScaleFactor")
        Me.txtDesignSoilScaleFactor.Name = "txtDesignSoilScaleFactor"
        '
        'lblDesignClipartScaleFactor
        '
        resources.ApplyResources(Me.lblDesignClipartScaleFactor, "lblDesignClipartScaleFactor")
        Me.lblDesignClipartScaleFactor.Name = "lblDesignClipartScaleFactor"
        Me.lblDesignClipartScaleFactor.Tag = "txtDesignClipartScaleFactor"
        '
        'txtDesignClipartScaleFactor
        '
        Me.txtDesignClipartScaleFactor.DecimalPlaces = 2
        Me.txtDesignClipartScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignClipartScaleFactor, "txtDesignClipartScaleFactor")
        Me.txtDesignClipartScaleFactor.Name = "txtDesignClipartScaleFactor"
        '
        'lblDesignTextScaleFactor
        '
        resources.ApplyResources(Me.lblDesignTextScaleFactor, "lblDesignTextScaleFactor")
        Me.lblDesignTextScaleFactor.Name = "lblDesignTextScaleFactor"
        Me.lblDesignTextScaleFactor.Tag = "txtDesignTextScaleFactor"
        '
        'txtDesignTextScaleFactor
        '
        Me.txtDesignTextScaleFactor.DecimalPlaces = 2
        Me.txtDesignTextScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignTextScaleFactor, "txtDesignTextScaleFactor")
        Me.txtDesignTextScaleFactor.Name = "txtDesignTextScaleFactor"
        '
        'lblDesignSignScaleFactor
        '
        resources.ApplyResources(Me.lblDesignSignScaleFactor, "lblDesignSignScaleFactor")
        Me.lblDesignSignScaleFactor.Name = "lblDesignSignScaleFactor"
        Me.lblDesignSignScaleFactor.Tag = "txtDesignSignScaleFactor"
        '
        'txtDesignSignScaleFactor
        '
        Me.txtDesignSignScaleFactor.DecimalPlaces = 2
        Me.txtDesignSignScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignSignScaleFactor, "txtDesignSignScaleFactor")
        Me.txtDesignSignScaleFactor.Name = "txtDesignSignScaleFactor"
        '
        'lblDesignTerrainLevelScaleFactor
        '
        resources.ApplyResources(Me.lblDesignTerrainLevelScaleFactor, "lblDesignTerrainLevelScaleFactor")
        Me.lblDesignTerrainLevelScaleFactor.Name = "lblDesignTerrainLevelScaleFactor"
        Me.lblDesignTerrainLevelScaleFactor.Tag = "txtDesignTerrainLevelScaleFactor"
        '
        'txtDesignTerrainLevelScaleFactor
        '
        Me.txtDesignTerrainLevelScaleFactor.DecimalPlaces = 2
        Me.txtDesignTerrainLevelScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtDesignTerrainLevelScaleFactor, "txtDesignTerrainLevelScaleFactor")
        Me.txtDesignTerrainLevelScaleFactor.Name = "txtDesignTerrainLevelScaleFactor"
        '
        'tabInfoPlot
        '
        Me.tabInfoPlot.Controls.Add(Me.GroupBox7)
        Me.tabInfoPlot.Controls.Add(Me.GroupBox6)
        Me.tabInfoPlot.Controls.Add(Me.frmPlotLRUD)
        Me.tabInfoPlot.Controls.Add(Me.frmPlotTranslationLine)
        Me.tabInfoPlot.Controls.Add(Me.frmPlotPoint)
        Me.tabInfoPlot.Controls.Add(Me.frmPlotPen)
        resources.ApplyResources(Me.tabInfoPlot, "tabInfoPlot")
        Me.tabInfoPlot.Name = "tabInfoPlot"
        Me.tabInfoPlot.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.txtPlotNoteTextFont)
        Me.GroupBox7.Controls.Add(Me.cmdPlotNoteTextFont)
        Me.GroupBox7.Controls.Add(Me.lblPlotNoteTextFont)
        Me.GroupBox7.Controls.Add(Me.cmdPlotNoteTextColor)
        Me.GroupBox7.Controls.Add(Me.lblPlotNoteTextColor)
        Me.GroupBox7.Controls.Add(Me.picPlotNoteTextColor)
        Me.GroupBox7.Controls.Add(Me.txtPlotNoteTextScaleFactor)
        Me.GroupBox7.Controls.Add(Me.lblPlotNoteTextScaleFactor)
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.TabStop = False
        '
        'txtPlotNoteTextFont
        '
        resources.ApplyResources(Me.txtPlotNoteTextFont, "txtPlotNoteTextFont")
        Me.txtPlotNoteTextFont.Name = "txtPlotNoteTextFont"
        Me.txtPlotNoteTextFont.ReadOnly = True
        '
        'cmdPlotNoteTextFont
        '
        resources.ApplyResources(Me.cmdPlotNoteTextFont, "cmdPlotNoteTextFont")
        Me.cmdPlotNoteTextFont.Name = "cmdPlotNoteTextFont"
        Me.cmdPlotNoteTextFont.UseVisualStyleBackColor = True
        '
        'lblPlotNoteTextFont
        '
        resources.ApplyResources(Me.lblPlotNoteTextFont, "lblPlotNoteTextFont")
        Me.lblPlotNoteTextFont.Name = "lblPlotNoteTextFont"
        Me.lblPlotNoteTextFont.Tag = "cmdPlotNoteTextFont;txtPlotNoteTextFont"
        '
        'cmdPlotNoteTextColor
        '
        resources.ApplyResources(Me.cmdPlotNoteTextColor, "cmdPlotNoteTextColor")
        Me.cmdPlotNoteTextColor.Name = "cmdPlotNoteTextColor"
        Me.cmdPlotNoteTextColor.UseVisualStyleBackColor = True
        '
        'lblPlotNoteTextColor
        '
        resources.ApplyResources(Me.lblPlotNoteTextColor, "lblPlotNoteTextColor")
        Me.lblPlotNoteTextColor.Name = "lblPlotNoteTextColor"
        Me.lblPlotNoteTextColor.Tag = "cmdPlotNoteTextColor;picPlotNoteTextColor"
        '
        'picPlotNoteTextColor
        '
        resources.ApplyResources(Me.picPlotNoteTextColor, "picPlotNoteTextColor")
        Me.picPlotNoteTextColor.Name = "picPlotNoteTextColor"
        Me.picPlotNoteTextColor.TabStop = False
        '
        'txtPlotNoteTextScaleFactor
        '
        Me.txtPlotNoteTextScaleFactor.DecimalPlaces = 2
        Me.txtPlotNoteTextScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtPlotNoteTextScaleFactor, "txtPlotNoteTextScaleFactor")
        Me.txtPlotNoteTextScaleFactor.Name = "txtPlotNoteTextScaleFactor"
        '
        'lblPlotNoteTextScaleFactor
        '
        resources.ApplyResources(Me.lblPlotNoteTextScaleFactor, "lblPlotNoteTextScaleFactor")
        Me.lblPlotNoteTextScaleFactor.Name = "lblPlotNoteTextScaleFactor"
        Me.lblPlotNoteTextScaleFactor.Tag = "txtPlotNoteTextScaleFactor"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.lblPlotSplaySelectedPenWidth)
        Me.GroupBox6.Controls.Add(Me.txtPlotSplaySelectedPenWidth)
        Me.GroupBox6.Controls.Add(Me.txtPlotSplayPenWidth)
        Me.GroupBox6.Controls.Add(Me.lblPlotSplayPenWidth)
        Me.GroupBox6.Controls.Add(Me.cboPlotSplayPenStyle)
        Me.GroupBox6.Controls.Add(Me.lblPlotSplayPenStyle)
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.TabStop = False
        '
        'lblPlotSplaySelectedPenWidth
        '
        resources.ApplyResources(Me.lblPlotSplaySelectedPenWidth, "lblPlotSplaySelectedPenWidth")
        Me.lblPlotSplaySelectedPenWidth.Name = "lblPlotSplaySelectedPenWidth"
        Me.lblPlotSplaySelectedPenWidth.Tag = "txtPlotSplaySelectedPenWidth"
        '
        'txtPlotSplaySelectedPenWidth
        '
        Me.txtPlotSplaySelectedPenWidth.DecimalPlaces = 4
        Me.txtPlotSplaySelectedPenWidth.Increment = New Decimal(New Integer() {5, 0, 0, 262144})
        resources.ApplyResources(Me.txtPlotSplaySelectedPenWidth, "txtPlotSplaySelectedPenWidth")
        Me.txtPlotSplaySelectedPenWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 262144})
        Me.txtPlotSplaySelectedPenWidth.Name = "txtPlotSplaySelectedPenWidth"
        Me.txtPlotSplaySelectedPenWidth.Value = New Decimal(New Integer() {50, 0, 0, 262144})
        '
        'txtPlotSplayPenWidth
        '
        Me.txtPlotSplayPenWidth.DecimalPlaces = 4
        Me.txtPlotSplayPenWidth.Increment = New Decimal(New Integer() {5, 0, 0, 262144})
        resources.ApplyResources(Me.txtPlotSplayPenWidth, "txtPlotSplayPenWidth")
        Me.txtPlotSplayPenWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 262144})
        Me.txtPlotSplayPenWidth.Name = "txtPlotSplayPenWidth"
        Me.txtPlotSplayPenWidth.Value = New Decimal(New Integer() {50, 0, 0, 262144})
        '
        'lblPlotSplayPenWidth
        '
        resources.ApplyResources(Me.lblPlotSplayPenWidth, "lblPlotSplayPenWidth")
        Me.lblPlotSplayPenWidth.Name = "lblPlotSplayPenWidth"
        Me.lblPlotSplayPenWidth.Tag = "txtPlotSplayPenWidth"
        '
        'cboPlotSplayPenStyle
        '
        Me.cboPlotSplayPenStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlotSplayPenStyle.FormattingEnabled = True
        Me.cboPlotSplayPenStyle.Items.AddRange(New Object() {resources.GetString("cboPlotSplayPenStyle.Items"), resources.GetString("cboPlotSplayPenStyle.Items1"), resources.GetString("cboPlotSplayPenStyle.Items2"), resources.GetString("cboPlotSplayPenStyle.Items3"), resources.GetString("cboPlotSplayPenStyle.Items4")})
        resources.ApplyResources(Me.cboPlotSplayPenStyle, "cboPlotSplayPenStyle")
        Me.cboPlotSplayPenStyle.Name = "cboPlotSplayPenStyle"
        '
        'lblPlotSplayPenStyle
        '
        resources.ApplyResources(Me.lblPlotSplayPenStyle, "lblPlotSplayPenStyle")
        Me.lblPlotSplayPenStyle.Name = "lblPlotSplayPenStyle"
        Me.lblPlotSplayPenStyle.Tag = "cboPlotSplayPenStyle"
        '
        'frmPlotLRUD
        '
        Me.frmPlotLRUD.Controls.Add(Me.lblPlotLRUDSelectedPenWidth)
        Me.frmPlotLRUD.Controls.Add(Me.txtPlotLRUDSelectedPenWidth)
        Me.frmPlotLRUD.Controls.Add(Me.txtPlotLRUDPenWidth)
        Me.frmPlotLRUD.Controls.Add(Me.lblPlotLRUDPenWidth)
        Me.frmPlotLRUD.Controls.Add(Me.cboPlotLRUDPenStyle)
        Me.frmPlotLRUD.Controls.Add(Me.lblPlotLRUDPenStyle)
        resources.ApplyResources(Me.frmPlotLRUD, "frmPlotLRUD")
        Me.frmPlotLRUD.Name = "frmPlotLRUD"
        Me.frmPlotLRUD.TabStop = False
        '
        'lblPlotLRUDSelectedPenWidth
        '
        resources.ApplyResources(Me.lblPlotLRUDSelectedPenWidth, "lblPlotLRUDSelectedPenWidth")
        Me.lblPlotLRUDSelectedPenWidth.Name = "lblPlotLRUDSelectedPenWidth"
        Me.lblPlotLRUDSelectedPenWidth.Tag = "txtPlotLRUDSelectedPenWidth"
        '
        'txtPlotLRUDSelectedPenWidth
        '
        Me.txtPlotLRUDSelectedPenWidth.DecimalPlaces = 4
        Me.txtPlotLRUDSelectedPenWidth.Increment = New Decimal(New Integer() {5, 0, 0, 262144})
        resources.ApplyResources(Me.txtPlotLRUDSelectedPenWidth, "txtPlotLRUDSelectedPenWidth")
        Me.txtPlotLRUDSelectedPenWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 262144})
        Me.txtPlotLRUDSelectedPenWidth.Name = "txtPlotLRUDSelectedPenWidth"
        Me.txtPlotLRUDSelectedPenWidth.Value = New Decimal(New Integer() {50, 0, 0, 262144})
        '
        'txtPlotLRUDPenWidth
        '
        Me.txtPlotLRUDPenWidth.DecimalPlaces = 4
        Me.txtPlotLRUDPenWidth.Increment = New Decimal(New Integer() {5, 0, 0, 262144})
        resources.ApplyResources(Me.txtPlotLRUDPenWidth, "txtPlotLRUDPenWidth")
        Me.txtPlotLRUDPenWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 262144})
        Me.txtPlotLRUDPenWidth.Name = "txtPlotLRUDPenWidth"
        Me.txtPlotLRUDPenWidth.Value = New Decimal(New Integer() {50, 0, 0, 262144})
        '
        'lblPlotLRUDPenWidth
        '
        resources.ApplyResources(Me.lblPlotLRUDPenWidth, "lblPlotLRUDPenWidth")
        Me.lblPlotLRUDPenWidth.Name = "lblPlotLRUDPenWidth"
        Me.lblPlotLRUDPenWidth.Tag = "txtPlotLRUDPenWidth"
        '
        'cboPlotLRUDPenStyle
        '
        Me.cboPlotLRUDPenStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlotLRUDPenStyle.FormattingEnabled = True
        Me.cboPlotLRUDPenStyle.Items.AddRange(New Object() {resources.GetString("cboPlotLRUDPenStyle.Items"), resources.GetString("cboPlotLRUDPenStyle.Items1"), resources.GetString("cboPlotLRUDPenStyle.Items2"), resources.GetString("cboPlotLRUDPenStyle.Items3"), resources.GetString("cboPlotLRUDPenStyle.Items4")})
        resources.ApplyResources(Me.cboPlotLRUDPenStyle, "cboPlotLRUDPenStyle")
        Me.cboPlotLRUDPenStyle.Name = "cboPlotLRUDPenStyle"
        '
        'lblPlotLRUDPenStyle
        '
        resources.ApplyResources(Me.lblPlotLRUDPenStyle, "lblPlotLRUDPenStyle")
        Me.lblPlotLRUDPenStyle.Name = "lblPlotLRUDPenStyle"
        Me.lblPlotLRUDPenStyle.Tag = "cboPlotLRUDPenStyle"
        '
        'frmPlotTranslationLine
        '
        Me.frmPlotTranslationLine.Controls.Add(Me.cmdPlotTranslationLinePenColor)
        Me.frmPlotTranslationLine.Controls.Add(Me.lblPlotTranslationLinePenColor)
        Me.frmPlotTranslationLine.Controls.Add(Me.picPlotTranslationLinePenColor)
        Me.frmPlotTranslationLine.Controls.Add(Me.txtPlotTranslationLinePenWidth)
        Me.frmPlotTranslationLine.Controls.Add(Me.lblPlotTranslationLinePenSize)
        Me.frmPlotTranslationLine.Controls.Add(Me.cboPlotTranslationLinePenStyle)
        Me.frmPlotTranslationLine.Controls.Add(Me.lblPlotTranslationLinePenStyle)
        resources.ApplyResources(Me.frmPlotTranslationLine, "frmPlotTranslationLine")
        Me.frmPlotTranslationLine.Name = "frmPlotTranslationLine"
        Me.frmPlotTranslationLine.TabStop = False
        '
        'cmdPlotTranslationLinePenColor
        '
        resources.ApplyResources(Me.cmdPlotTranslationLinePenColor, "cmdPlotTranslationLinePenColor")
        Me.cmdPlotTranslationLinePenColor.Name = "cmdPlotTranslationLinePenColor"
        Me.cmdPlotTranslationLinePenColor.UseVisualStyleBackColor = True
        '
        'lblPlotTranslationLinePenColor
        '
        resources.ApplyResources(Me.lblPlotTranslationLinePenColor, "lblPlotTranslationLinePenColor")
        Me.lblPlotTranslationLinePenColor.Name = "lblPlotTranslationLinePenColor"
        Me.lblPlotTranslationLinePenColor.Tag = "cmdPlotTranslationLinePenColor;picPlotTranslationLinePenColor"
        '
        'picPlotTranslationLinePenColor
        '
        resources.ApplyResources(Me.picPlotTranslationLinePenColor, "picPlotTranslationLinePenColor")
        Me.picPlotTranslationLinePenColor.Name = "picPlotTranslationLinePenColor"
        Me.picPlotTranslationLinePenColor.TabStop = False
        '
        'txtPlotTranslationLinePenWidth
        '
        Me.txtPlotTranslationLinePenWidth.DecimalPlaces = 4
        Me.txtPlotTranslationLinePenWidth.Increment = New Decimal(New Integer() {5, 0, 0, 262144})
        resources.ApplyResources(Me.txtPlotTranslationLinePenWidth, "txtPlotTranslationLinePenWidth")
        Me.txtPlotTranslationLinePenWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 262144})
        Me.txtPlotTranslationLinePenWidth.Name = "txtPlotTranslationLinePenWidth"
        Me.txtPlotTranslationLinePenWidth.Value = New Decimal(New Integer() {50, 0, 0, 262144})
        '
        'lblPlotTranslationLinePenSize
        '
        resources.ApplyResources(Me.lblPlotTranslationLinePenSize, "lblPlotTranslationLinePenSize")
        Me.lblPlotTranslationLinePenSize.Name = "lblPlotTranslationLinePenSize"
        Me.lblPlotTranslationLinePenSize.Tag = "txtPlotTranslationLinePenWidth"
        '
        'cboPlotTranslationLinePenStyle
        '
        Me.cboPlotTranslationLinePenStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlotTranslationLinePenStyle.FormattingEnabled = True
        Me.cboPlotTranslationLinePenStyle.Items.AddRange(New Object() {resources.GetString("cboPlotTranslationLinePenStyle.Items"), resources.GetString("cboPlotTranslationLinePenStyle.Items1"), resources.GetString("cboPlotTranslationLinePenStyle.Items2"), resources.GetString("cboPlotTranslationLinePenStyle.Items3"), resources.GetString("cboPlotTranslationLinePenStyle.Items4")})
        resources.ApplyResources(Me.cboPlotTranslationLinePenStyle, "cboPlotTranslationLinePenStyle")
        Me.cboPlotTranslationLinePenStyle.Name = "cboPlotTranslationLinePenStyle"
        '
        'lblPlotTranslationLinePenStyle
        '
        resources.ApplyResources(Me.lblPlotTranslationLinePenStyle, "lblPlotTranslationLinePenStyle")
        Me.lblPlotTranslationLinePenStyle.Name = "lblPlotTranslationLinePenStyle"
        Me.lblPlotTranslationLinePenStyle.Tag = "cboPlotTranslationLinePenStyle"
        '
        'frmPlotPoint
        '
        Me.frmPlotPoint.Controls.Add(Me.txtPlotTextFont)
        Me.frmPlotPoint.Controls.Add(Me.cmdPlotTextFont)
        Me.frmPlotPoint.Controls.Add(Me.cmdPlotPointColor)
        Me.frmPlotPoint.Controls.Add(Me.lblPlotTextFont)
        Me.frmPlotPoint.Controls.Add(Me.lblPlotPointColor)
        Me.frmPlotPoint.Controls.Add(Me.cmdPlotTextColor)
        Me.frmPlotPoint.Controls.Add(Me.picPlotPointColor)
        Me.frmPlotPoint.Controls.Add(Me.lblPlotTextColor)
        Me.frmPlotPoint.Controls.Add(Me.cboPlotPointSymbol)
        Me.frmPlotPoint.Controls.Add(Me.picPlotTextColor)
        Me.frmPlotPoint.Controls.Add(Me.txtPlotSelectedPointSize)
        Me.frmPlotPoint.Controls.Add(Me.txtPlotTextScaleFactor)
        Me.frmPlotPoint.Controls.Add(Me.txtPlotPointSize)
        Me.frmPlotPoint.Controls.Add(Me.lblPlotTextScaleFactor)
        Me.frmPlotPoint.Controls.Add(Me.lblPlotSelectedPointSize)
        Me.frmPlotPoint.Controls.Add(Me.lblPlotPointSize)
        Me.frmPlotPoint.Controls.Add(Me.lblPlotPointSymbol)
        resources.ApplyResources(Me.frmPlotPoint, "frmPlotPoint")
        Me.frmPlotPoint.Name = "frmPlotPoint"
        Me.frmPlotPoint.TabStop = False
        '
        'txtPlotTextFont
        '
        resources.ApplyResources(Me.txtPlotTextFont, "txtPlotTextFont")
        Me.txtPlotTextFont.Name = "txtPlotTextFont"
        Me.txtPlotTextFont.ReadOnly = True
        '
        'cmdPlotTextFont
        '
        resources.ApplyResources(Me.cmdPlotTextFont, "cmdPlotTextFont")
        Me.cmdPlotTextFont.Name = "cmdPlotTextFont"
        Me.cmdPlotTextFont.UseVisualStyleBackColor = True
        '
        'cmdPlotPointColor
        '
        resources.ApplyResources(Me.cmdPlotPointColor, "cmdPlotPointColor")
        Me.cmdPlotPointColor.Name = "cmdPlotPointColor"
        Me.cmdPlotPointColor.UseVisualStyleBackColor = True
        '
        'lblPlotTextFont
        '
        resources.ApplyResources(Me.lblPlotTextFont, "lblPlotTextFont")
        Me.lblPlotTextFont.Name = "lblPlotTextFont"
        Me.lblPlotTextFont.Tag = "txtPlotTextFont;cmdPlotTextFont"
        '
        'lblPlotPointColor
        '
        resources.ApplyResources(Me.lblPlotPointColor, "lblPlotPointColor")
        Me.lblPlotPointColor.Name = "lblPlotPointColor"
        Me.lblPlotPointColor.Tag = "cmdPlotPointColor;picPlotPointColor"
        '
        'cmdPlotTextColor
        '
        resources.ApplyResources(Me.cmdPlotTextColor, "cmdPlotTextColor")
        Me.cmdPlotTextColor.Name = "cmdPlotTextColor"
        Me.cmdPlotTextColor.UseVisualStyleBackColor = True
        '
        'picPlotPointColor
        '
        resources.ApplyResources(Me.picPlotPointColor, "picPlotPointColor")
        Me.picPlotPointColor.Name = "picPlotPointColor"
        Me.picPlotPointColor.TabStop = False
        '
        'lblPlotTextColor
        '
        resources.ApplyResources(Me.lblPlotTextColor, "lblPlotTextColor")
        Me.lblPlotTextColor.Name = "lblPlotTextColor"
        Me.lblPlotTextColor.Tag = "cmdPlotTextColor;picPlotTextColor"
        '
        'cboPlotPointSymbol
        '
        Me.cboPlotPointSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboPlotPointSymbol, "cboPlotPointSymbol")
        Me.cboPlotPointSymbol.Items.AddRange(New Object() {resources.GetString("cboPlotPointSymbol.Items"), resources.GetString("cboPlotPointSymbol.Items1"), resources.GetString("cboPlotPointSymbol.Items2"), resources.GetString("cboPlotPointSymbol.Items3"), resources.GetString("cboPlotPointSymbol.Items4"), resources.GetString("cboPlotPointSymbol.Items5"), resources.GetString("cboPlotPointSymbol.Items6"), resources.GetString("cboPlotPointSymbol.Items7")})
        Me.cboPlotPointSymbol.Name = "cboPlotPointSymbol"
        Me.cboPlotPointSymbol.Tag = "cboPlotPointSymbol"
        '
        'picPlotTextColor
        '
        resources.ApplyResources(Me.picPlotTextColor, "picPlotTextColor")
        Me.picPlotTextColor.Name = "picPlotTextColor"
        Me.picPlotTextColor.TabStop = False
        '
        'txtPlotSelectedPointSize
        '
        Me.txtPlotSelectedPointSize.DecimalPlaces = 2
        Me.txtPlotSelectedPointSize.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtPlotSelectedPointSize, "txtPlotSelectedPointSize")
        Me.txtPlotSelectedPointSize.Name = "txtPlotSelectedPointSize"
        '
        'txtPlotTextScaleFactor
        '
        Me.txtPlotTextScaleFactor.DecimalPlaces = 2
        Me.txtPlotTextScaleFactor.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtPlotTextScaleFactor, "txtPlotTextScaleFactor")
        Me.txtPlotTextScaleFactor.Name = "txtPlotTextScaleFactor"
        '
        'txtPlotPointSize
        '
        Me.txtPlotPointSize.DecimalPlaces = 2
        Me.txtPlotPointSize.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        resources.ApplyResources(Me.txtPlotPointSize, "txtPlotPointSize")
        Me.txtPlotPointSize.Name = "txtPlotPointSize"
        '
        'lblPlotTextScaleFactor
        '
        resources.ApplyResources(Me.lblPlotTextScaleFactor, "lblPlotTextScaleFactor")
        Me.lblPlotTextScaleFactor.Name = "lblPlotTextScaleFactor"
        Me.lblPlotTextScaleFactor.Tag = "txtPlotTextScaleFactor"
        '
        'lblPlotSelectedPointSize
        '
        resources.ApplyResources(Me.lblPlotSelectedPointSize, "lblPlotSelectedPointSize")
        Me.lblPlotSelectedPointSize.Name = "lblPlotSelectedPointSize"
        Me.lblPlotSelectedPointSize.Tag = "txtPlotSelectedPointSize"
        '
        'lblPlotPointSize
        '
        resources.ApplyResources(Me.lblPlotPointSize, "lblPlotPointSize")
        Me.lblPlotPointSize.Name = "lblPlotPointSize"
        Me.lblPlotPointSize.Tag = "txtPlotPointSize"
        '
        'lblPlotPointSymbol
        '
        resources.ApplyResources(Me.lblPlotPointSymbol, "lblPlotPointSymbol")
        Me.lblPlotPointSymbol.Name = "lblPlotPointSymbol"
        Me.lblPlotPointSymbol.Tag = "cboPlotPointSymbol"
        '
        'frmPlotPen
        '
        Me.frmPlotPen.Controls.Add(Me.cmdPlotPenColor)
        Me.frmPlotPen.Controls.Add(Me.lblPlotPenColor)
        Me.frmPlotPen.Controls.Add(Me.picPlotPenColor)
        Me.frmPlotPen.Controls.Add(Me.txtPlotPenWidth)
        Me.frmPlotPen.Controls.Add(Me.lblPlotPenWidth)
        Me.frmPlotPen.Controls.Add(Me.lblPlotSelectedPenWidth)
        Me.frmPlotPen.Controls.Add(Me.cboPlotPenStyle)
        Me.frmPlotPen.Controls.Add(Me.txtPlotSelectedPenWidth)
        Me.frmPlotPen.Controls.Add(Me.lblPlotPenStyle)
        resources.ApplyResources(Me.frmPlotPen, "frmPlotPen")
        Me.frmPlotPen.Name = "frmPlotPen"
        Me.frmPlotPen.TabStop = False
        '
        'cmdPlotPenColor
        '
        resources.ApplyResources(Me.cmdPlotPenColor, "cmdPlotPenColor")
        Me.cmdPlotPenColor.Name = "cmdPlotPenColor"
        Me.cmdPlotPenColor.UseVisualStyleBackColor = True
        '
        'lblPlotPenColor
        '
        resources.ApplyResources(Me.lblPlotPenColor, "lblPlotPenColor")
        Me.lblPlotPenColor.Name = "lblPlotPenColor"
        Me.lblPlotPenColor.Tag = "picPlotPenColor;cmdPlotPenColor"
        '
        'picPlotPenColor
        '
        resources.ApplyResources(Me.picPlotPenColor, "picPlotPenColor")
        Me.picPlotPenColor.Name = "picPlotPenColor"
        Me.picPlotPenColor.TabStop = False
        '
        'txtPlotPenWidth
        '
        Me.txtPlotPenWidth.DecimalPlaces = 4
        Me.txtPlotPenWidth.Increment = New Decimal(New Integer() {5, 0, 0, 262144})
        resources.ApplyResources(Me.txtPlotPenWidth, "txtPlotPenWidth")
        Me.txtPlotPenWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 262144})
        Me.txtPlotPenWidth.Name = "txtPlotPenWidth"
        Me.txtPlotPenWidth.Value = New Decimal(New Integer() {50, 0, 0, 262144})
        '
        'lblPlotPenWidth
        '
        resources.ApplyResources(Me.lblPlotPenWidth, "lblPlotPenWidth")
        Me.lblPlotPenWidth.Name = "lblPlotPenWidth"
        Me.lblPlotPenWidth.Tag = "txtPlotPenWidth"
        '
        'lblPlotSelectedPenWidth
        '
        resources.ApplyResources(Me.lblPlotSelectedPenWidth, "lblPlotSelectedPenWidth")
        Me.lblPlotSelectedPenWidth.Name = "lblPlotSelectedPenWidth"
        Me.lblPlotSelectedPenWidth.Tag = "txtPlotSelectedPenWidth"
        '
        'cboPlotPenStyle
        '
        Me.cboPlotPenStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlotPenStyle.FormattingEnabled = True
        Me.cboPlotPenStyle.Items.AddRange(New Object() {resources.GetString("cboPlotPenStyle.Items"), resources.GetString("cboPlotPenStyle.Items1"), resources.GetString("cboPlotPenStyle.Items2"), resources.GetString("cboPlotPenStyle.Items3"), resources.GetString("cboPlotPenStyle.Items4")})
        resources.ApplyResources(Me.cboPlotPenStyle, "cboPlotPenStyle")
        Me.cboPlotPenStyle.Name = "cboPlotPenStyle"
        '
        'txtPlotSelectedPenWidth
        '
        Me.txtPlotSelectedPenWidth.DecimalPlaces = 4
        Me.txtPlotSelectedPenWidth.Increment = New Decimal(New Integer() {5, 0, 0, 262144})
        resources.ApplyResources(Me.txtPlotSelectedPenWidth, "txtPlotSelectedPenWidth")
        Me.txtPlotSelectedPenWidth.Minimum = New Decimal(New Integer() {5, 0, 0, 262144})
        Me.txtPlotSelectedPenWidth.Name = "txtPlotSelectedPenWidth"
        Me.txtPlotSelectedPenWidth.Value = New Decimal(New Integer() {50, 0, 0, 262144})
        '
        'lblPlotPenStyle
        '
        resources.ApplyResources(Me.lblPlotPenStyle, "lblPlotPenStyle")
        Me.lblPlotPenStyle.Name = "lblPlotPenStyle"
        Me.lblPlotPenStyle.Tag = "cboPlotPenStyle"
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblAddScale, Me.txtAddScale, Me.btnAdd, Me.btnAddAsCopy, Me.sep1, Me.btnRemove, Me.btnRemoveAll, Me.sep2, Me.btnClear, Me.sep3, Me.btnExport, Me.btnImport})
        Me.tbMain.Name = "tbMain"
        '
        'lblAddScale
        '
        Me.lblAddScale.Name = "lblAddScale"
        resources.ApplyResources(Me.lblAddScale, "lblAddScale")
        '
        'txtAddScale
        '
        resources.ApplyResources(Me.txtAddScale, "txtAddScale")
        Me.txtAddScale.Name = "txtAddScale"
        Me.txtAddScale.ShortcutsEnabled = False
        '
        'btnAdd
        '
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'btnAddAsCopy
        '
        resources.ApplyResources(Me.btnAddAsCopy, "btnAddAsCopy")
        Me.btnAddAsCopy.Name = "btnAddAsCopy"
        '
        'sep1
        '
        Me.sep1.Name = "sep1"
        resources.ApplyResources(Me.sep1, "sep1")
        '
        'btnRemove
        '
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        '
        'btnRemoveAll
        '
        resources.ApplyResources(Me.btnRemoveAll, "btnRemoveAll")
        Me.btnRemoveAll.Name = "btnRemoveAll"
        '
        'sep2
        '
        Me.sep2.Name = "sep2"
        resources.ApplyResources(Me.sep2, "sep2")
        '
        'btnClear
        '
        Me.btnClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.Name = "btnClear"
        '
        'sep3
        '
        Me.sep3.Name = "sep3"
        resources.ApplyResources(Me.sep3, "sep3")
        '
        'btnExport
        '
        Me.btnExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.Name = "btnExport"
        '
        'btnImport
        '
        Me.btnImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        resources.ApplyResources(Me.btnImport, "btnImport")
        Me.btnImport.Name = "btnImport"
        '
        'frmScaleRules
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.tbMain)
        Me.Controls.Add(Me.tabInfo)
        Me.Controls.Add(Me.lv)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IconOptions.Icon = CType(resources.GetObject("frmScaleRules.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.scale
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScaleRules"
        Me.tabInfo.ResumeLayout(False)
        Me.tabInfoMain.ResumeLayout(False)
        Me.tabInfoMain.PerformLayout()
        CType(Me.picScaleWarning, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tanInfoCategories.ResumeLayout(False)
        CType(Me.grdCategoriesVisibility, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInfODesign.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtBaseMediumLinesScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaseUltraLightLinesScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaseLightLinesScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaseHeavyLinesScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaseLineWidthScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frrmDesign.ResumeLayout(False)
        Me.frrmDesign.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtDesignCrossSectionTextScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtDesignCrossSectionMarkerTextScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignCrossSectionMarkerArrowScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.txtDesignExtraScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignExtraTextScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignTextureScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignSoilScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignClipartScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignTextScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignSignScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDesignTerrainLevelScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabInfoPlot.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.picPlotNoteTextColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotNoteTextScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.txtPlotSplaySelectedPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotSplayPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmPlotLRUD.ResumeLayout(False)
        Me.frmPlotLRUD.PerformLayout()
        CType(Me.txtPlotLRUDSelectedPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotLRUDPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmPlotTranslationLine.ResumeLayout(False)
        Me.frmPlotTranslationLine.PerformLayout()
        CType(Me.picPlotTranslationLinePenColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotTranslationLinePenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmPlotPoint.ResumeLayout(False)
        Me.frmPlotPoint.PerformLayout()
        CType(Me.picPlotPointColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPlotTextColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotSelectedPointSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotTextScaleFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotPointSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.frmPlotPen.ResumeLayout(False)
        Me.frmPlotPen.PerformLayout()
        CType(Me.picPlotPenColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPlotSelectedPenWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents tabInfo As System.Windows.Forms.TabControl
    Friend WithEvents tabInfoMain As System.Windows.Forms.TabPage
    Friend WithEvents lblScale As System.Windows.Forms.Label
    Friend WithEvents tabInfODesign As System.Windows.Forms.TabPage
    Friend WithEvents tabInfoPlot As System.Windows.Forms.TabPage
    Friend WithEvents txtScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents lblAddScale As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtAddScale As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents sep1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tanInfoCategories As System.Windows.Forms.TabPage
    Friend WithEvents lblScaleWarning As System.Windows.Forms.Label
    Friend WithEvents picScaleWarning As System.Windows.Forms.PictureBox
    Friend WithEvents grdCategoriesVisibility As cSurveyPC.cGrid
    Friend WithEvents btnAddAsCopy As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRemoveAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents sep3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPlotNoteTextFont As System.Windows.Forms.TextBox
    Friend WithEvents cmdPlotNoteTextFont As System.Windows.Forms.Button
    Friend WithEvents lblPlotNoteTextFont As System.Windows.Forms.Label
    Friend WithEvents cmdPlotNoteTextColor As System.Windows.Forms.Button
    Friend WithEvents lblPlotNoteTextColor As System.Windows.Forms.Label
    Friend WithEvents picPlotNoteTextColor As System.Windows.Forms.PictureBox
    Friend WithEvents txtPlotNoteTextScaleFactor As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotNoteTextScaleFactor As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents lblPlotSplaySelectedPenWidth As System.Windows.Forms.Label
    Friend WithEvents txtPlotSplaySelectedPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPlotSplayPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotSplayPenWidth As System.Windows.Forms.Label
    Friend WithEvents cboPlotSplayPenStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlotSplayPenStyle As System.Windows.Forms.Label
    Friend WithEvents frmPlotLRUD As System.Windows.Forms.GroupBox
    Friend WithEvents lblPlotLRUDSelectedPenWidth As System.Windows.Forms.Label
    Friend WithEvents txtPlotLRUDSelectedPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPlotLRUDPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotLRUDPenWidth As System.Windows.Forms.Label
    Friend WithEvents cboPlotLRUDPenStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlotLRUDPenStyle As System.Windows.Forms.Label
    Friend WithEvents frmPlotTranslationLine As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPlotTranslationLinePenColor As System.Windows.Forms.Button
    Friend WithEvents lblPlotTranslationLinePenColor As System.Windows.Forms.Label
    Friend WithEvents picPlotTranslationLinePenColor As System.Windows.Forms.PictureBox
    Friend WithEvents txtPlotTranslationLinePenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotTranslationLinePenSize As System.Windows.Forms.Label
    Friend WithEvents cboPlotTranslationLinePenStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblPlotTranslationLinePenStyle As System.Windows.Forms.Label
    Friend WithEvents frmPlotPoint As System.Windows.Forms.GroupBox
    Friend WithEvents txtPlotTextFont As System.Windows.Forms.TextBox
    Friend WithEvents cmdPlotTextFont As System.Windows.Forms.Button
    Friend WithEvents cmdPlotPointColor As System.Windows.Forms.Button
    Friend WithEvents lblPlotTextFont As System.Windows.Forms.Label
    Friend WithEvents lblPlotPointColor As System.Windows.Forms.Label
    Friend WithEvents cmdPlotTextColor As System.Windows.Forms.Button
    Friend WithEvents picPlotPointColor As System.Windows.Forms.PictureBox
    Friend WithEvents lblPlotTextColor As System.Windows.Forms.Label
    Friend WithEvents cboPlotPointSymbol As System.Windows.Forms.ComboBox
    Friend WithEvents picPlotTextColor As System.Windows.Forms.PictureBox
    Friend WithEvents txtPlotSelectedPointSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPlotTextScaleFactor As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtPlotPointSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotTextScaleFactor As System.Windows.Forms.Label
    Friend WithEvents lblPlotSelectedPointSize As System.Windows.Forms.Label
    Friend WithEvents lblPlotPointSize As System.Windows.Forms.Label
    Friend WithEvents lblPlotPointSymbol As System.Windows.Forms.Label
    Friend WithEvents frmPlotPen As System.Windows.Forms.GroupBox
    Friend WithEvents cmdPlotPenColor As System.Windows.Forms.Button
    Friend WithEvents lblPlotPenColor As System.Windows.Forms.Label
    Friend WithEvents picPlotPenColor As System.Windows.Forms.PictureBox
    Friend WithEvents txtPlotPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotPenWidth As System.Windows.Forms.Label
    Friend WithEvents lblPlotSelectedPenWidth As System.Windows.Forms.Label
    Friend WithEvents cboPlotPenStyle As System.Windows.Forms.ComboBox
    Friend WithEvents txtPlotSelectedPenWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblPlotPenStyle As System.Windows.Forms.Label
    Friend WithEvents colCategoryIndex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategoryName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategoryVisibility As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents frrmDesign As GroupBox
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents txtDesignExtraScaleFactor As NumericUpDown
    Friend WithEvents lblDesignExtraTextScaleFactor As Label
    Friend WithEvents lblDesignExtraScaleFactor As Label
    Friend WithEvents txtDesignExtraTextScaleFactor As NumericUpDown
    Friend WithEvents lblDesignTextureScale As Label
    Friend WithEvents txtDesignTextureScaleFactor As NumericUpDown
    Friend WithEvents txtDesignTextFont As TextBox
    Friend WithEvents cmdDesignTextFont As Button
    Friend WithEvents lblDesignTextFont As Label
    Friend WithEvents lblDesignSoilScale As Label
    Friend WithEvents txtDesignSoilScaleFactor As NumericUpDown
    Friend WithEvents lblDesignClipartScaleFactor As Label
    Friend WithEvents txtDesignClipartScaleFactor As NumericUpDown
    Friend WithEvents lblDesignTextScaleFactor As Label
    Friend WithEvents txtDesignTextScaleFactor As NumericUpDown
    Friend WithEvents lblDesignSignScaleFactor As Label
    Friend WithEvents txtDesignSignScaleFactor As NumericUpDown
    Friend WithEvents lblDesignTerrainLevelScaleFactor As Label
    Friend WithEvents txtDesignTerrainLevelScaleFactor As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBaseMediumLinesScaleFactor As NumericUpDown
    Friend WithEvents txtBaseUltraLightLinesScaleFactor As NumericUpDown
    Friend WithEvents txtBaseLightLinesScaleFactor As NumericUpDown
    Friend WithEvents txtBaseHeavyLinesScaleFactor As NumericUpDown
    Friend WithEvents lblBaseLinesScaleFactor As Label
    Friend WithEvents txtBaseLineWidthScaleFactor As NumericUpDown
    Friend WithEvents lblBaseLineWidthScaleFactor As Label
    Friend WithEvents btnClear As ToolStripButton
    Friend WithEvents sep2 As ToolStripSeparator
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtDesignCrossSectionMarkerArrowScaleFactor As NumericUpDown
    Friend WithEvents lblDesignCrossSectionTextScaleFactor As Label
    Friend WithEvents lblDesignCrossSectionMarkerArrowScaleFactor As Label
    Friend WithEvents txtDesignCrossSectionTextScaleFactor As NumericUpDown
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblDesignCrossSectionMarkerTextScaleFactor As Label
    Friend WithEvents txtDesignCrossSectionMarkerTextScaleFactor As NumericUpDown
End Class
