<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoCave
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoCave))
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.pnlSurveyInfo = New System.Windows.Forms.Panel()
        Me.pnlSurvey = New System.Windows.Forms.Panel()
        Me.cboSurveyInfoCaveBranch = New System.Windows.Forms.ComboBox()
        Me.lblSurveyInfoCaveBranch = New System.Windows.Forms.Label()
        Me.cboSurveyInfoCave = New System.Windows.Forms.ComboBox()
        Me.grdSurveyInfo = New cSurveyPC.cGrid()
        Me.colSurveyInfoName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSurveyInfoValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mnuSurveyInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSurveyInfoCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSurveyInfoCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSurveyInfoExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSurveyInfoCave = New System.Windows.Forms.Label()
        Me.pnlLinkedSurveys = New System.Windows.Forms.Panel()
        Me.cboSurveyInfoFilename = New System.Windows.Forms.ComboBox()
        Me.lblSurveyInfoFilename = New System.Windows.Forms.Label()
        Me.pnlSurveyInfo.SuspendLayout()
        Me.pnlSurvey.SuspendLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuSurveyInfo.SuspendLayout()
        Me.pnlLinkedSurveys.SuspendLayout()
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
        Me.pnlSurveyInfo.Controls.Add(Me.pnlSurvey)
        Me.pnlSurveyInfo.Controls.Add(Me.pnlLinkedSurveys)
        Me.pnlSurveyInfo.Name = "pnlSurveyInfo"
        '
        'pnlSurvey
        '
        Me.pnlSurvey.Controls.Add(Me.cboSurveyInfoCaveBranch)
        Me.pnlSurvey.Controls.Add(Me.lblSurveyInfoCaveBranch)
        Me.pnlSurvey.Controls.Add(Me.cboSurveyInfoCave)
        Me.pnlSurvey.Controls.Add(Me.grdSurveyInfo)
        Me.pnlSurvey.Controls.Add(Me.lblSurveyInfoCave)
        resources.ApplyResources(Me.pnlSurvey, "pnlSurvey")
        Me.pnlSurvey.Name = "pnlSurvey"
        '
        'cboSurveyInfoCaveBranch
        '
        resources.ApplyResources(Me.cboSurveyInfoCaveBranch, "cboSurveyInfoCaveBranch")
        Me.cboSurveyInfoCaveBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSurveyInfoCaveBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSurveyInfoCaveBranch.Name = "cboSurveyInfoCaveBranch"
        '
        'lblSurveyInfoCaveBranch
        '
        resources.ApplyResources(Me.lblSurveyInfoCaveBranch, "lblSurveyInfoCaveBranch")
        Me.lblSurveyInfoCaveBranch.Name = "lblSurveyInfoCaveBranch"
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
        Me.grdSurveyInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSurveyInfoName, Me.colSurveyInfoValue})
        Me.grdSurveyInfo.ContextMenuStrip = Me.mnuSurveyInfo
        Me.grdSurveyInfo.Name = "grdSurveyInfo"
        Me.grdSurveyInfo.ReadOnly = True
        Me.grdSurveyInfo.RowHeadersVisible = False
        Me.grdSurveyInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdSurveyInfo.ShowEditingIcon = False
        '
        'colSurveyInfoName
        '
        Me.colSurveyInfoName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSurveyInfoName.FillWeight = 50.0!
        resources.ApplyResources(Me.colSurveyInfoName, "colSurveyInfoName")
        Me.colSurveyInfoName.Name = "colSurveyInfoName"
        Me.colSurveyInfoName.ReadOnly = True
        '
        'colSurveyInfoValue
        '
        Me.colSurveyInfoValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSurveyInfoValue.FillWeight = 50.0!
        resources.ApplyResources(Me.colSurveyInfoValue, "colSurveyInfoValue")
        Me.colSurveyInfoValue.Name = "colSurveyInfoValue"
        Me.colSurveyInfoValue.ReadOnly = True
        '
        'mnuSurveyInfo
        '
        resources.ApplyResources(Me.mnuSurveyInfo, "mnuSurveyInfo")
        Me.mnuSurveyInfo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSurveyInfoCopy, Me.mnuSurveyInfoCopyAll, Me.ToolStripMenuItem1, Me.mnuSurveyInfoExport})
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
        'pnlLinkedSurveys
        '
        Me.pnlLinkedSurveys.Controls.Add(Me.cboSurveyInfoFilename)
        Me.pnlLinkedSurveys.Controls.Add(Me.lblSurveyInfoFilename)
        resources.ApplyResources(Me.pnlLinkedSurveys, "pnlLinkedSurveys")
        Me.pnlLinkedSurveys.Name = "pnlLinkedSurveys"
        '
        'cboSurveyInfoFilename
        '
        resources.ApplyResources(Me.cboSurveyInfoFilename, "cboSurveyInfoFilename")
        Me.cboSurveyInfoFilename.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSurveyInfoFilename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSurveyInfoFilename.Name = "cboSurveyInfoFilename"
        '
        'lblSurveyInfoFilename
        '
        resources.ApplyResources(Me.lblSurveyInfoFilename, "lblSurveyInfoFilename")
        Me.lblSurveyInfoFilename.Name = "lblSurveyInfoFilename"
        '
        'frmInfoCave
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdClose
        Me.Controls.Add(Me.pnlSurveyInfo)
        Me.Controls.Add(Me.cmdClose)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoCave"
        Me.SaveAndRestoreSettings = True
        Me.pnlSurveyInfo.ResumeLayout(False)
        Me.pnlSurvey.ResumeLayout(False)
        Me.pnlSurvey.PerformLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuSurveyInfo.ResumeLayout(False)
        Me.pnlLinkedSurveys.ResumeLayout(False)
        Me.pnlLinkedSurveys.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents pnlSurveyInfo As System.Windows.Forms.Panel
    Friend WithEvents cboSurveyInfoCave As System.Windows.Forms.ComboBox
    Friend WithEvents grdSurveyInfo As cSurveyPC.cGrid
    Friend WithEvents lblSurveyInfoCave As System.Windows.Forms.Label
    Friend WithEvents colSurveyInfoName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSurveyInfoValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuSurveyInfo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSurveyInfoCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSurveyInfoCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboSurveyInfoCaveBranch As System.Windows.Forms.ComboBox
    Friend WithEvents lblSurveyInfoCaveBranch As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSurveyInfoExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboSurveyInfoFilename As ComboBox
    Friend WithEvents lblSurveyInfoFilename As Label
    Friend WithEvents pnlLinkedSurveys As Panel
    Friend WithEvents pnlSurvey As Panel
End Class
