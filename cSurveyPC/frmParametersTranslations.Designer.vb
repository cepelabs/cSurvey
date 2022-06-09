<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmParametersTranslations
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersTranslations))
        Me.chkShowLine = New DevExpress.XtraEditors.CheckEdit()
        Me.chkShowOriginalPosition = New DevExpress.XtraEditors.CheckEdit()
        Me.mnuTraslationsGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTraslationsGridFilterByLabel = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtTraslationsGridFilterBy = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTraslationsGridRemoveFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkOriginalPositionColorGray = New DevExpress.XtraEditors.CheckEdit()
        Me.cboOriginalPositionColorMode = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblOriginalPositionColorMode = New DevExpress.XtraEditors.LabelControl()
        Me.txtTranslationsThreshold = New DevExpress.XtraEditors.SpinEdit()
        Me.lblTranslationsThreshold = New DevExpress.XtraEditors.LabelControl()
        Me.chkOriginalPositionOnlyTranslated = New DevExpress.XtraEditors.CheckEdit()
        Me.chkOriginalPositionOverDesign = New DevExpress.XtraEditors.CheckEdit()
        Me.lblTranslationsThresholdUM = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colCaveBranchCaveColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaveBranchCave = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtGridCaveName = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.colCaveBranchBranchColor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaveBranchBranch = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colCaveBranchX = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtGridTranslationXY = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colCaveBranchY = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.chkShowLine.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkShowOriginalPosition.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuTraslationsGrid.SuspendLayout()
        CType(Me.chkOriginalPositionColorGray.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboOriginalPositionColorMode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTranslationsThreshold.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOriginalPositionOnlyTranslated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkOriginalPositionOverDesign.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGridCaveName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGridTranslationXY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkShowLine
        '
        resources.ApplyResources(Me.chkShowLine, "chkShowLine")
        Me.chkShowLine.Name = "chkShowLine"
        Me.chkShowLine.Properties.Caption = resources.GetString("chkShowLine.Properties.Caption")
        '
        'chkShowOriginalPosition
        '
        resources.ApplyResources(Me.chkShowOriginalPosition, "chkShowOriginalPosition")
        Me.chkShowOriginalPosition.Name = "chkShowOriginalPosition"
        Me.chkShowOriginalPosition.Properties.Caption = resources.GetString("chkShowOriginalPosition.Properties.Caption")
        '
        'mnuTraslationsGrid
        '
        resources.ApplyResources(Me.mnuTraslationsGrid, "mnuTraslationsGrid")
        Me.mnuTraslationsGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTraslationsGridFilterByLabel, Me.txtTraslationsGridFilterBy, Me.ToolStripMenuItem1, Me.mnuTraslationsGridRemoveFilter})
        Me.mnuTraslationsGrid.Name = "mnuTraslationsGrid"
        '
        'mnuTraslationsGridFilterByLabel
        '
        Me.mnuTraslationsGridFilterByLabel.Name = "mnuTraslationsGridFilterByLabel"
        resources.ApplyResources(Me.mnuTraslationsGridFilterByLabel, "mnuTraslationsGridFilterByLabel")
        '
        'txtTraslationsGridFilterBy
        '
        resources.ApplyResources(Me.txtTraslationsGridFilterBy, "txtTraslationsGridFilterBy")
        Me.txtTraslationsGridFilterBy.Name = "txtTraslationsGridFilterBy"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuTraslationsGridRemoveFilter
        '
        Me.mnuTraslationsGridRemoveFilter.Name = "mnuTraslationsGridRemoveFilter"
        resources.ApplyResources(Me.mnuTraslationsGridRemoveFilter, "mnuTraslationsGridRemoveFilter")
        '
        'chkOriginalPositionColorGray
        '
        resources.ApplyResources(Me.chkOriginalPositionColorGray, "chkOriginalPositionColorGray")
        Me.chkOriginalPositionColorGray.Name = "chkOriginalPositionColorGray"
        Me.chkOriginalPositionColorGray.Properties.Appearance.Font = CType(resources.GetObject("chkOriginalPositionColorGray.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkOriginalPositionColorGray.Properties.Appearance.Options.UseFont = True
        Me.chkOriginalPositionColorGray.Properties.Caption = resources.GetString("chkOriginalPositionColorGray.Properties.Caption")
        '
        'cboOriginalPositionColorMode
        '
        resources.ApplyResources(Me.cboOriginalPositionColorMode, "cboOriginalPositionColorMode")
        Me.cboOriginalPositionColorMode.Name = "cboOriginalPositionColorMode"
        Me.cboOriginalPositionColorMode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("cboOriginalPositionColorMode.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.cboOriginalPositionColorMode.Properties.Items.AddRange(New Object() {resources.GetString("cboOriginalPositionColorMode.Properties.Items"), resources.GetString("cboOriginalPositionColorMode.Properties.Items1")})
        Me.cboOriginalPositionColorMode.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'lblOriginalPositionColorMode
        '
        resources.ApplyResources(Me.lblOriginalPositionColorMode, "lblOriginalPositionColorMode")
        Me.lblOriginalPositionColorMode.Appearance.Font = CType(resources.GetObject("lblOriginalPositionColorMode.Appearance.Font"), System.Drawing.Font)
        Me.lblOriginalPositionColorMode.Appearance.Options.UseFont = True
        Me.lblOriginalPositionColorMode.Name = "lblOriginalPositionColorMode"
        '
        'txtTranslationsThreshold
        '
        resources.ApplyResources(Me.txtTranslationsThreshold, "txtTranslationsThreshold")
        Me.txtTranslationsThreshold.Name = "txtTranslationsThreshold"
        Me.txtTranslationsThreshold.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtTranslationsThreshold.Properties.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtTranslationsThreshold.Properties.DisplayFormat.FormatString = "N2"
        Me.txtTranslationsThreshold.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTranslationsThreshold.Properties.EditFormat.FormatString = "N2"
        Me.txtTranslationsThreshold.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTranslationsThreshold.Properties.MaxValue = New Decimal(New Integer() {10000, 0, 0, 0})
        '
        'lblTranslationsThreshold
        '
        resources.ApplyResources(Me.lblTranslationsThreshold, "lblTranslationsThreshold")
        Me.lblTranslationsThreshold.Appearance.Font = CType(resources.GetObject("lblTranslationsThreshold.Appearance.Font"), System.Drawing.Font)
        Me.lblTranslationsThreshold.Appearance.Options.UseFont = True
        Me.lblTranslationsThreshold.Name = "lblTranslationsThreshold"
        '
        'chkOriginalPositionOnlyTranslated
        '
        resources.ApplyResources(Me.chkOriginalPositionOnlyTranslated, "chkOriginalPositionOnlyTranslated")
        Me.chkOriginalPositionOnlyTranslated.Name = "chkOriginalPositionOnlyTranslated"
        Me.chkOriginalPositionOnlyTranslated.Properties.Appearance.Font = CType(resources.GetObject("chkOriginalPositionOnlyTranslated.Properties.Appearance.Font"), System.Drawing.Font)
        Me.chkOriginalPositionOnlyTranslated.Properties.Appearance.Options.UseFont = True
        Me.chkOriginalPositionOnlyTranslated.Properties.Caption = resources.GetString("chkOriginalPositionOnlyTranslated.Properties.Caption")
        '
        'chkOriginalPositionOverDesign
        '
        resources.ApplyResources(Me.chkOriginalPositionOverDesign, "chkOriginalPositionOverDesign")
        Me.chkOriginalPositionOverDesign.Name = "chkOriginalPositionOverDesign"
        Me.chkOriginalPositionOverDesign.Properties.Caption = resources.GetString("chkOriginalPositionOverDesign.Properties.Caption")
        '
        'lblTranslationsThresholdUM
        '
        resources.ApplyResources(Me.lblTranslationsThresholdUM, "lblTranslationsThresholdUM")
        Me.lblTranslationsThresholdUM.Appearance.Font = CType(resources.GetObject("lblTranslationsThresholdUM.Appearance.Font"), System.Drawing.Font)
        Me.lblTranslationsThresholdUM.Appearance.Options.UseFont = True
        Me.lblTranslationsThresholdUM.Name = "lblTranslationsThresholdUM"
        '
        'GridControl1
        '
        resources.ApplyResources(Me.GridControl1, "GridControl1")
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.txtGridTranslationXY, Me.txtGridCaveName})
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colCaveBranchCaveColor, Me.colCaveBranchCave, Me.colCaveBranchBranchColor, Me.colCaveBranchBranch, Me.colCaveBranchX, Me.colCaveBranchY})
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        '
        'colCaveBranchCaveColor
        '
        resources.ApplyResources(Me.colCaveBranchCaveColor, "colCaveBranchCaveColor")
        Me.colCaveBranchCaveColor.FieldName = "CaveColor"
        Me.colCaveBranchCaveColor.MaxWidth = 10
        Me.colCaveBranchCaveColor.MinWidth = 10
        Me.colCaveBranchCaveColor.Name = "colCaveBranchCaveColor"
        Me.colCaveBranchCaveColor.OptionsColumn.AllowEdit = False
        Me.colCaveBranchCaveColor.OptionsColumn.AllowMove = False
        Me.colCaveBranchCaveColor.OptionsColumn.FixedWidth = True
        Me.colCaveBranchCaveColor.OptionsColumn.ReadOnly = True
        Me.colCaveBranchCaveColor.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'colCaveBranchCave
        '
        resources.ApplyResources(Me.colCaveBranchCave, "colCaveBranchCave")
        Me.colCaveBranchCave.ColumnEdit = Me.txtGridCaveName
        Me.colCaveBranchCave.FieldName = "Cave"
        Me.colCaveBranchCave.Name = "colCaveBranchCave"
        Me.colCaveBranchCave.OptionsColumn.AllowEdit = False
        Me.colCaveBranchCave.OptionsColumn.AllowMove = False
        Me.colCaveBranchCave.OptionsColumn.ReadOnly = True
        '
        'txtGridCaveName
        '
        Me.txtGridCaveName.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.[True]
        resources.ApplyResources(Me.txtGridCaveName, "txtGridCaveName")
        Me.txtGridCaveName.Name = "txtGridCaveName"
        '
        'colCaveBranchBranchColor
        '
        resources.ApplyResources(Me.colCaveBranchBranchColor, "colCaveBranchBranchColor")
        Me.colCaveBranchBranchColor.FieldName = "BranchColor"
        Me.colCaveBranchBranchColor.MaxWidth = 10
        Me.colCaveBranchBranchColor.MinWidth = 10
        Me.colCaveBranchBranchColor.Name = "colCaveBranchBranchColor"
        Me.colCaveBranchBranchColor.OptionsColumn.AllowEdit = False
        Me.colCaveBranchBranchColor.OptionsColumn.AllowMove = False
        Me.colCaveBranchBranchColor.OptionsColumn.FixedWidth = True
        Me.colCaveBranchBranchColor.OptionsColumn.ReadOnly = True
        Me.colCaveBranchBranchColor.UnboundType = DevExpress.Data.UnboundColumnType.[String]
        '
        'colCaveBranchBranch
        '
        resources.ApplyResources(Me.colCaveBranchBranch, "colCaveBranchBranch")
        Me.colCaveBranchBranch.ColumnEdit = Me.txtGridCaveName
        Me.colCaveBranchBranch.FieldName = "Branch"
        Me.colCaveBranchBranch.Name = "colCaveBranchBranch"
        Me.colCaveBranchBranch.OptionsColumn.AllowEdit = False
        Me.colCaveBranchBranch.OptionsColumn.AllowMove = False
        Me.colCaveBranchBranch.OptionsColumn.ReadOnly = True
        '
        'colCaveBranchX
        '
        resources.ApplyResources(Me.colCaveBranchX, "colCaveBranchX")
        Me.colCaveBranchX.ColumnEdit = Me.txtGridTranslationXY
        Me.colCaveBranchX.DisplayFormat.FormatString = "N2"
        Me.colCaveBranchX.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCaveBranchX.FieldName = "X"
        Me.colCaveBranchX.MaxWidth = 70
        Me.colCaveBranchX.MinWidth = 70
        Me.colCaveBranchX.Name = "colCaveBranchX"
        Me.colCaveBranchX.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        '
        'txtGridTranslationXY
        '
        resources.ApplyResources(Me.txtGridTranslationXY, "txtGridTranslationXY")
        Me.txtGridTranslationXY.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(CType(resources.GetObject("txtGridTranslationXY.Buttons"), DevExpress.XtraEditors.Controls.ButtonPredefines))})
        Me.txtGridTranslationXY.DisplayFormat.FormatString = "N2"
        Me.txtGridTranslationXY.EditFormat.FormatString = "N2"
        Me.txtGridTranslationXY.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtGridTranslationXY.MaskSettings.Set("mask", "n")
        Me.txtGridTranslationXY.Name = "txtGridTranslationXY"
        '
        'colCaveBranchY
        '
        resources.ApplyResources(Me.colCaveBranchY, "colCaveBranchY")
        Me.colCaveBranchY.ColumnEdit = Me.txtGridTranslationXY
        Me.colCaveBranchY.DisplayFormat.FormatString = "N2"
        Me.colCaveBranchY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colCaveBranchY.FieldName = "Y"
        Me.colCaveBranchY.MaxWidth = 70
        Me.colCaveBranchY.MinWidth = 70
        Me.colCaveBranchY.Name = "colCaveBranchY"
        Me.colCaveBranchY.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[False]
        '
        'frmParametersTranslations
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.lblTranslationsThresholdUM)
        Me.Controls.Add(Me.chkOriginalPositionOverDesign)
        Me.Controls.Add(Me.chkOriginalPositionOnlyTranslated)
        Me.Controls.Add(Me.lblTranslationsThreshold)
        Me.Controls.Add(Me.txtTranslationsThreshold)
        Me.Controls.Add(Me.chkOriginalPositionColorGray)
        Me.Controls.Add(Me.cboOriginalPositionColorMode)
        Me.Controls.Add(Me.lblOriginalPositionColorMode)
        Me.Controls.Add(Me.chkShowLine)
        Me.Controls.Add(Me.chkShowOriginalPosition)
        Me.Name = "frmParametersTranslations"
        CType(Me.chkShowLine.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkShowOriginalPosition.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuTraslationsGrid.ResumeLayout(False)
        Me.mnuTraslationsGrid.PerformLayout()
        CType(Me.chkOriginalPositionColorGray.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboOriginalPositionColorMode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTranslationsThreshold.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOriginalPositionOnlyTranslated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkOriginalPositionOverDesign.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGridCaveName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGridTranslationXY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkShowLine As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkShowOriginalPosition As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkOriginalPositionColorGray As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents cboOriginalPositionColorMode As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblOriginalPositionColorMode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents mnuTraslationsGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTraslationsGridFilterByLabel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTraslationsGridFilterBy As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTraslationsGridRemoveFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTranslationsThreshold As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents lblTranslationsThreshold As DevExpress.XtraEditors.LabelControl
    Friend WithEvents chkOriginalPositionOnlyTranslated As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkOriginalPositionOverDesign As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents lblTranslationsThresholdUM As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colCaveBranchCave As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaveBranchBranch As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaveBranchX As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtGridTranslationXY As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colCaveBranchY As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtGridCaveName As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents colCaveBranchCaveColor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colCaveBranchBranchColor As DevExpress.XtraGrid.Columns.GridColumn
End Class
