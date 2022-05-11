<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmParametersTranslations
    Inherits cForm

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.chkShowLine = New System.Windows.Forms.CheckBox()
        Me.chkShowOriginalPosition = New System.Windows.Forms.CheckBox()
        Me.mnuTraslationsGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTraslationsGridFilterByLabel = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtTraslationsGridFilterBy = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTraslationsGridRemoveFilter = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkOriginalPositionColorGray = New System.Windows.Forms.CheckBox()
        Me.cboOriginalPositionColorMode = New System.Windows.Forms.ComboBox()
        Me.lblOriginalPositionColorMode = New System.Windows.Forms.Label()
        Me.grdTraslations = New cSurveyPC.cGrid()
        Me.colCave = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBranch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPriority = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colBreakPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtTranslationsThreshold = New System.Windows.Forms.NumericUpDown()
        Me.lblTranslationsThreshold = New System.Windows.Forms.Label()
        Me.chkOriginalPositionOnlyTranslated = New System.Windows.Forms.CheckBox()
        Me.chkOriginalPositionOverDesign = New System.Windows.Forms.CheckBox()
        Me.lblTranslationsThresholdUM = New System.Windows.Forms.Label()
        Me.mnuTraslationsGrid.SuspendLayout()
        CType(Me.grdTraslations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTranslationsThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkShowLine
        '
        resources.ApplyResources(Me.chkShowLine, "chkShowLine")
        Me.chkShowLine.Name = "chkShowLine"
        Me.chkShowLine.UseVisualStyleBackColor = True
        '
        'chkShowOriginalPosition
        '
        resources.ApplyResources(Me.chkShowOriginalPosition, "chkShowOriginalPosition")
        Me.chkShowOriginalPosition.Name = "chkShowOriginalPosition"
        Me.chkShowOriginalPosition.UseVisualStyleBackColor = True
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
        Me.txtTraslationsGridFilterBy.Name = "txtTraslationsGridFilterBy"
        resources.ApplyResources(Me.txtTraslationsGridFilterBy, "txtTraslationsGridFilterBy")
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
        '
        'cboOriginalPositionColorMode
        '
        resources.ApplyResources(Me.cboOriginalPositionColorMode, "cboOriginalPositionColorMode")
        Me.cboOriginalPositionColorMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboOriginalPositionColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOriginalPositionColorMode.Items.AddRange(New Object() {resources.GetString("cboOriginalPositionColorMode.Items"), resources.GetString("cboOriginalPositionColorMode.Items1")})
        Me.cboOriginalPositionColorMode.Name = "cboOriginalPositionColorMode"
        '
        'lblOriginalPositionColorMode
        '
        resources.ApplyResources(Me.lblOriginalPositionColorMode, "lblOriginalPositionColorMode")
        Me.lblOriginalPositionColorMode.Name = "lblOriginalPositionColorMode"
        '
        'grdTraslations
        '
        Me.grdTraslations.AllowUserToAddRows = False
        Me.grdTraslations.AllowUserToDeleteRows = False
        Me.grdTraslations.AllowUserToResizeRows = False
        resources.ApplyResources(Me.grdTraslations, "grdTraslations")
        Me.grdTraslations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdTraslations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCave, Me.colBranch, Me.colX, Me.colY, Me.colPriority, Me.colBreakPercentage})
        Me.grdTraslations.ContextMenuStrip = Me.mnuTraslationsGrid
        Me.grdTraslations.Name = "grdTraslations"
        Me.grdTraslations.RowHeadersVisible = False
        '
        'colCave
        '
        Me.colCave.FillWeight = 162.4366!
        resources.ApplyResources(Me.colCave, "colCave")
        Me.colCave.Name = "colCave"
        Me.colCave.ReadOnly = True
        Me.colCave.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCave.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colBranch
        '
        Me.colBranch.FillWeight = 225.1904!
        resources.ApplyResources(Me.colBranch, "colBranch")
        Me.colBranch.Name = "colBranch"
        Me.colBranch.ReadOnly = True
        '
        'colX
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colX.DefaultCellStyle = DataGridViewCellStyle1
        Me.colX.FillWeight = 6.186547!
        resources.ApplyResources(Me.colX, "colX")
        Me.colX.Name = "colX"
        '
        'colY
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colY.DefaultCellStyle = DataGridViewCellStyle2
        Me.colY.FillWeight = 6.186547!
        resources.ApplyResources(Me.colY, "colY")
        Me.colY.Name = "colY"
        '
        'colPriority
        '
        resources.ApplyResources(Me.colPriority, "colPriority")
        Me.colPriority.Name = "colPriority"
        '
        'colBreakPercentage
        '
        resources.ApplyResources(Me.colBreakPercentage, "colBreakPercentage")
        Me.colBreakPercentage.Name = "colBreakPercentage"
        '
        'txtTranslationsThreshold
        '
        resources.ApplyResources(Me.txtTranslationsThreshold, "txtTranslationsThreshold")
        Me.txtTranslationsThreshold.DecimalPlaces = 1
        Me.txtTranslationsThreshold.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.txtTranslationsThreshold.Name = "txtTranslationsThreshold"
        '
        'lblTranslationsThreshold
        '
        resources.ApplyResources(Me.lblTranslationsThreshold, "lblTranslationsThreshold")
        Me.lblTranslationsThreshold.Name = "lblTranslationsThreshold"
        '
        'chkOriginalPositionOnlyTranslated
        '
        resources.ApplyResources(Me.chkOriginalPositionOnlyTranslated, "chkOriginalPositionOnlyTranslated")
        Me.chkOriginalPositionOnlyTranslated.Name = "chkOriginalPositionOnlyTranslated"
        '
        'chkOriginalPositionOverDesign
        '
        resources.ApplyResources(Me.chkOriginalPositionOverDesign, "chkOriginalPositionOverDesign")
        Me.chkOriginalPositionOverDesign.Name = "chkOriginalPositionOverDesign"
        Me.chkOriginalPositionOverDesign.UseVisualStyleBackColor = True
        '
        'lblTranslationsThresholdUM
        '
        resources.ApplyResources(Me.lblTranslationsThresholdUM, "lblTranslationsThresholdUM")
        Me.lblTranslationsThresholdUM.Name = "lblTranslationsThresholdUM"
        '
        'frmParametersTranslations
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
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
        Me.Controls.Add(Me.grdTraslations)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametersTranslations"
        Me.mnuTraslationsGrid.ResumeLayout(False)
        Me.mnuTraslationsGrid.PerformLayout()
        CType(Me.grdTraslations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTranslationsThreshold, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grdTraslations As cSurveyPC.cGrid
    Friend WithEvents chkShowLine As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowOriginalPosition As System.Windows.Forms.CheckBox
    Friend WithEvents chkOriginalPositionColorGray As System.Windows.Forms.CheckBox
    Friend WithEvents cboOriginalPositionColorMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblOriginalPositionColorMode As System.Windows.Forms.Label
    Friend WithEvents mnuTraslationsGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuTraslationsGridFilterByLabel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtTraslationsGridFilterBy As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuTraslationsGridRemoveFilter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colCave As DataGridViewTextBoxColumn
    Friend WithEvents colBranch As DataGridViewTextBoxColumn
    Friend WithEvents colX As DataGridViewTextBoxColumn
    Friend WithEvents colY As DataGridViewTextBoxColumn
    Friend WithEvents colPriority As DataGridViewComboBoxColumn
    Friend WithEvents colBreakPercentage As DataGridViewTextBoxColumn
    Friend WithEvents txtTranslationsThreshold As NumericUpDown
    Friend WithEvents lblTranslationsThreshold As Label
    Friend WithEvents chkOriginalPositionOnlyTranslated As CheckBox
    Friend WithEvents chkOriginalPositionOverDesign As CheckBox
    Friend WithEvents lblTranslationsThresholdUM As Label
End Class
