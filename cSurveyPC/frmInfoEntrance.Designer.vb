<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmInfoEntrance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoEntrance))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.pnlSurveyInfo = New System.Windows.Forms.Panel()
        Me.cboSurveyInfoCave = New System.Windows.Forms.ComboBox()
        Me.grdSurveyInfo = New cSurveyPC.cGrid()
        Me.mnuSurveyInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSurveyInfoCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSurveyInfoCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSurveyInfoCopyCell = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSurveyInfoExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSurveyInfoCave = New System.Windows.Forms.Label()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSurveyInfoName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSurveyInfoValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.pnlSurveyInfo.SuspendLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuSurveyInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'pnlSurveyInfo
        '
        resources.ApplyResources(Me.pnlSurveyInfo, "pnlSurveyInfo")
        Me.pnlSurveyInfo.Controls.Add(Me.cboSurveyInfoCave)
        Me.pnlSurveyInfo.Controls.Add(Me.grdSurveyInfo)
        Me.pnlSurveyInfo.Controls.Add(Me.lblSurveyInfoCave)
        Me.pnlSurveyInfo.Name = "pnlSurveyInfo"
        '
        'cboSurveyInfoCave
        '
        resources.ApplyResources(Me.cboSurveyInfoCave, "cboSurveyInfoCave")
        Me.cboSurveyInfoCave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSurveyInfoCave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSurveyInfoCave.Name = "cboSurveyInfoCave"
        '
        'grdSurveyInfo
        '
        Me.grdSurveyInfo.AllowUserToAddRows = False
        Me.grdSurveyInfo.AllowUserToDeleteRows = False
        resources.ApplyResources(Me.grdSurveyInfo, "grdSurveyInfo")
        Me.grdSurveyInfo.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdSurveyInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdSurveyInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdSurveyInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.colSurveyInfoName, Me.colSurveyInfoValue, Me.Column1, Me.Column2, Me.Column3, Me.Column5, Me.Column4})
        Me.grdSurveyInfo.ContextMenuStrip = Me.mnuSurveyInfo
        Me.grdSurveyInfo.Name = "grdSurveyInfo"
        Me.grdSurveyInfo.ReadOnly = True
        Me.grdSurveyInfo.RowHeadersVisible = False
        Me.grdSurveyInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdSurveyInfo.ShowEditingIcon = False
        '
        'mnuSurveyInfo
        '
        resources.ApplyResources(Me.mnuSurveyInfo, "mnuSurveyInfo")
        Me.mnuSurveyInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSurveyInfoCopy, Me.mnuSurveyInfoCopyAll, Me.mnuSurveyInfoCopyCell, Me.ToolStripMenuItem1, Me.mnuSurveyInfoExport})
        Me.mnuSurveyInfo.Name = "mnuSurveyInfo"
        '
        'mnuSurveyInfoCopy
        '
        Me.mnuSurveyInfoCopy.Image = Global.cSurveyPC.My.Resources.Resources.page_copy
        Me.mnuSurveyInfoCopy.Name = "mnuSurveyInfoCopy"
        resources.ApplyResources(Me.mnuSurveyInfoCopy, "mnuSurveyInfoCopy")
        '
        'mnuSurveyInfoCopyAll
        '
        Me.mnuSurveyInfoCopyAll.Name = "mnuSurveyInfoCopyAll"
        resources.ApplyResources(Me.mnuSurveyInfoCopyAll, "mnuSurveyInfoCopyAll")
        '
        'mnuSurveyInfoCopyCell
        '
        Me.mnuSurveyInfoCopyCell.Name = "mnuSurveyInfoCopyCell"
        resources.ApplyResources(Me.mnuSurveyInfoCopyCell, "mnuSurveyInfoCopyCell")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuSurveyInfoExport
        '
        Me.mnuSurveyInfoExport.Name = "mnuSurveyInfoExport"
        resources.ApplyResources(Me.mnuSurveyInfoExport, "mnuSurveyInfoExport")
        '
        'lblSurveyInfoCave
        '
        resources.ApplyResources(Me.lblSurveyInfoCave, "lblSurveyInfoCave")
        Me.lblSurveyInfoCave.Name = "lblSurveyInfoCave"
        '
        'Column6
        '
        resources.ApplyResources(Me.Column6, "Column6")
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'colSurveyInfoName
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colSurveyInfoName.DefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.colSurveyInfoName, "colSurveyInfoName")
        Me.colSurveyInfoName.Name = "colSurveyInfoName"
        Me.colSurveyInfoName.ReadOnly = True
        '
        'colSurveyInfoValue
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colSurveyInfoValue.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.colSurveyInfoValue, "colSurveyInfoValue")
        Me.colSurveyInfoValue.Name = "colSurveyInfoValue"
        Me.colSurveyInfoValue.ReadOnly = True
        '
        'Column1
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle5
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column5
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.Column5, "Column5")
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column4
        '
        resources.ApplyResources(Me.Column4, "Column4")
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'frmInfoEntrance
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdClose
        Me.Controls.Add(Me.pnlSurveyInfo)
        Me.Controls.Add(Me.cmdClose)
        Me.MinimizeBox = False
        Me.Name = "frmInfoEntrance"
        Me.pnlSurveyInfo.ResumeLayout(False)
        Me.pnlSurveyInfo.PerformLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuSurveyInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents pnlSurveyInfo As System.Windows.Forms.Panel
    Friend WithEvents cboSurveyInfoCave As System.Windows.Forms.ComboBox
    Friend WithEvents grdSurveyInfo As cSurveyPC.cGrid
    Friend WithEvents lblSurveyInfoCave As System.Windows.Forms.Label
    Friend WithEvents mnuSurveyInfo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSurveyInfoCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSurveyInfoCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSurveyInfoExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSurveyInfoCopyCell As ToolStripMenuItem
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents colSurveyInfoName As DataGridViewTextBoxColumn
    Friend WithEvents colSurveyInfoValue As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewButtonColumn
End Class
