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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlSurveyRing = New System.Windows.Forms.Panel()
        Me.txtSurveyRingAverageError = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grdSurveyRing = New cSurveyPC.cGrid()
        Me.Selected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTrigPointsStation0 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colError = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colErrAbs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colErrX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colErrY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colErrZ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRingLen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTrigPoints = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTrigPointsList = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Colore = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.mnuInfoRing = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuInfoRingCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInfoRingCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInfoRingSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInfoRingDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInfoRingRevertSelect = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInfoRingColor = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuInfoRingColorBrowse = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInfoRingColorReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuInfoRingExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.oColorDialog = New System.Windows.Forms.ColorDialog()
        Me.pnlSurveyRing.SuspendLayout()
        CType(Me.grdSurveyRing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuInfoRing.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSurveyRing
        '
        resources.ApplyResources(Me.pnlSurveyRing, "pnlSurveyRing")
        Me.pnlSurveyRing.Controls.Add(Me.txtSurveyRingAverageError)
        Me.pnlSurveyRing.Controls.Add(Me.Label4)
        Me.pnlSurveyRing.Controls.Add(Me.grdSurveyRing)
        Me.pnlSurveyRing.Name = "pnlSurveyRing"
        '
        'txtSurveyRingAverageError
        '
        resources.ApplyResources(Me.txtSurveyRingAverageError, "txtSurveyRingAverageError")
        Me.txtSurveyRingAverageError.Name = "txtSurveyRingAverageError"
        Me.txtSurveyRingAverageError.ReadOnly = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'grdSurveyRing
        '
        Me.grdSurveyRing.AllowUserToAddRows = False
        Me.grdSurveyRing.AllowUserToDeleteRows = False
        resources.ApplyResources(Me.grdSurveyRing, "grdSurveyRing")
        Me.grdSurveyRing.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdSurveyRing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdSurveyRing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSurveyRing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Selected, Me.colTrigPointsStation0, Me.colError, Me.colErrAbs, Me.colErrX, Me.colErrY, Me.colErrZ, Me.colRingLen, Me.colTrigPoints, Me.colTrigPointsList, Me.Colore})
        Me.grdSurveyRing.ContextMenuStrip = Me.mnuInfoRing
        Me.grdSurveyRing.Name = "grdSurveyRing"
        Me.grdSurveyRing.RowHeadersVisible = False
        Me.grdSurveyRing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdSurveyRing.ShowEditingIcon = False
        '
        'Selected
        '
        Me.Selected.Frozen = True
        resources.ApplyResources(Me.Selected, "Selected")
        Me.Selected.Name = "Selected"
        '
        'colTrigPointsStation0
        '
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colTrigPointsStation0.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.colTrigPointsStation0, "colTrigPointsStation0")
        Me.colTrigPointsStation0.Name = "colTrigPointsStation0"
        Me.colTrigPointsStation0.ReadOnly = True
        '
        'colError
        '
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colError.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.colError, "colError")
        Me.colError.Name = "colError"
        Me.colError.ReadOnly = True
        '
        'colErrAbs
        '
        resources.ApplyResources(Me.colErrAbs, "colErrAbs")
        Me.colErrAbs.Name = "colErrAbs"
        Me.colErrAbs.ReadOnly = True
        '
        'colErrX
        '
        resources.ApplyResources(Me.colErrX, "colErrX")
        Me.colErrX.Name = "colErrX"
        Me.colErrX.ReadOnly = True
        '
        'colErrY
        '
        resources.ApplyResources(Me.colErrY, "colErrY")
        Me.colErrY.Name = "colErrY"
        Me.colErrY.ReadOnly = True
        '
        'colErrZ
        '
        resources.ApplyResources(Me.colErrZ, "colErrZ")
        Me.colErrZ.Name = "colErrZ"
        Me.colErrZ.ReadOnly = True
        '
        'colRingLen
        '
        resources.ApplyResources(Me.colRingLen, "colRingLen")
        Me.colRingLen.Name = "colRingLen"
        Me.colRingLen.ReadOnly = True
        '
        'colTrigPoints
        '
        resources.ApplyResources(Me.colTrigPoints, "colTrigPoints")
        Me.colTrigPoints.Name = "colTrigPoints"
        Me.colTrigPoints.ReadOnly = True
        '
        'colTrigPointsList
        '
        resources.ApplyResources(Me.colTrigPointsList, "colTrigPointsList")
        Me.colTrigPointsList.Name = "colTrigPointsList"
        Me.colTrigPointsList.ReadOnly = True
        '
        'Colore
        '
        Me.Colore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Colore, "Colore")
        Me.Colore.Name = "Colore"
        Me.Colore.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Colore.Text = "..."
        Me.Colore.UseColumnTextForButtonValue = True
        '
        'mnuInfoRing
        '
        resources.ApplyResources(Me.mnuInfoRing, "mnuInfoRing")
        Me.mnuInfoRing.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInfoRingCopy, Me.mnuInfoRingCopyAll, Me.ToolStripMenuItem1, Me.mnuInfoRingSelectAll, Me.mnuInfoRingDeselectAll, Me.mnuInfoRingRevertSelect, Me.ToolStripMenuItem2, Me.mnuInfoRingColor, Me.ToolStripMenuItem4, Me.mnuInfoRingExport})
        Me.mnuInfoRing.Name = "mnuSegmentInfo"
        '
        'mnuInfoRingCopy
        '
        Me.mnuInfoRingCopy.Image = Global.cSurveyPC.My.Resources.Resources.page_copy
        Me.mnuInfoRingCopy.Name = "mnuInfoRingCopy"
        resources.ApplyResources(Me.mnuInfoRingCopy, "mnuInfoRingCopy")
        '
        'mnuInfoRingCopyAll
        '
        Me.mnuInfoRingCopyAll.Name = "mnuInfoRingCopyAll"
        resources.ApplyResources(Me.mnuInfoRingCopyAll, "mnuInfoRingCopyAll")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuInfoRingSelectAll
        '
        Me.mnuInfoRingSelectAll.Name = "mnuInfoRingSelectAll"
        resources.ApplyResources(Me.mnuInfoRingSelectAll, "mnuInfoRingSelectAll")
        '
        'mnuInfoRingDeselectAll
        '
        Me.mnuInfoRingDeselectAll.Name = "mnuInfoRingDeselectAll"
        resources.ApplyResources(Me.mnuInfoRingDeselectAll, "mnuInfoRingDeselectAll")
        '
        'mnuInfoRingRevertSelect
        '
        Me.mnuInfoRingRevertSelect.Name = "mnuInfoRingRevertSelect"
        resources.ApplyResources(Me.mnuInfoRingRevertSelect, "mnuInfoRingRevertSelect")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuInfoRingColor
        '
        Me.mnuInfoRingColor.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuInfoRingColorBrowse, Me.ToolStripMenuItem3, Me.mnuInfoRingColorReset})
        Me.mnuInfoRingColor.Name = "mnuInfoRingColor"
        resources.ApplyResources(Me.mnuInfoRingColor, "mnuInfoRingColor")
        '
        'mnuInfoRingColorBrowse
        '
        Me.mnuInfoRingColorBrowse.Name = "mnuInfoRingColorBrowse"
        resources.ApplyResources(Me.mnuInfoRingColorBrowse, "mnuInfoRingColorBrowse")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'mnuInfoRingColorReset
        '
        Me.mnuInfoRingColorReset.Name = "mnuInfoRingColorReset"
        resources.ApplyResources(Me.mnuInfoRingColorReset, "mnuInfoRingColorReset")
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        resources.ApplyResources(Me.ToolStripMenuItem4, "ToolStripMenuItem4")
        '
        'mnuInfoRingExport
        '
        Me.mnuInfoRingExport.Name = "mnuInfoRingExport"
        resources.ApplyResources(Me.mnuInfoRingExport, "mnuInfoRingExport")
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
        'frmInfoRing
        '
        Me.AcceptButton = Me.cmdApply
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.pnlSurveyRing)
        Me.MinimizeBox = False
        Me.Name = "frmInfoRing"
        Me.pnlSurveyRing.ResumeLayout(False)
        Me.pnlSurveyRing.PerformLayout()
        CType(Me.grdSurveyRing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuInfoRing.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlSurveyRing As System.Windows.Forms.Panel
    Friend WithEvents txtSurveyRingAverageError As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdSurveyRing As cSurveyPC.cGrid
    Friend WithEvents mnuInfoRing As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuInfoRingCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInfoRingCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuInfoRingSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInfoRingDeselectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInfoRingRevertSelect As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents oColorDialog As System.Windows.Forms.ColorDialog
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuInfoRingColor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuInfoRingColorBrowse As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuInfoRingColorReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Selected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTrigPointsStation0 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colError As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colErrAbs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colErrX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colErrY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colErrZ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRingLen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTrigPoints As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTrigPointsList As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Colore As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuInfoRingExport As System.Windows.Forms.ToolStripMenuItem
End Class
