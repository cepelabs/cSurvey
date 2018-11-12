<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoSession
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoSession))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cboSurveyInfoSession = New System.Windows.Forms.ComboBox()
        Me.mnuSurveyInfo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuSurveyInfoCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSurveyInfoCopyAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuSurveyInfoExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSurveyInfoSession = New System.Windows.Forms.Label()
        Me.chrSessions = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabStats = New System.Windows.Forms.TabPage()
        Me.grdSurveyInfo = New cSurveyPC.cGrid()
        Me.colSurveyInfoName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSurveyInfoValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabCharts = New System.Windows.Forms.TabPage()
        Me.cboChartType = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mnuSurveyInfo.SuspendLayout()
        CType(Me.chrSessions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.tabStats.SuspendLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCharts.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cboSurveyInfoSession
        '
        resources.ApplyResources(Me.cboSurveyInfoSession, "cboSurveyInfoSession")
        Me.cboSurveyInfoSession.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSurveyInfoSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSurveyInfoSession.Name = "cboSurveyInfoSession"
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
        'lblSurveyInfoSession
        '
        resources.ApplyResources(Me.lblSurveyInfoSession, "lblSurveyInfoSession")
        Me.lblSurveyInfoSession.Name = "lblSurveyInfoSession"
        '
        'chrSessions
        '
        resources.ApplyResources(Me.chrSessions, "chrSessions")
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.Name = "ChartArea1"
        Me.chrSessions.ChartAreas.Add(ChartArea1)
        Me.chrSessions.Name = "chrSessions"
        Series1.ChartArea = "ChartArea1"
        Series1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.Name = "Series1"
        Me.chrSessions.Series.Add(Series1)
        '
        'tabMain
        '
        resources.ApplyResources(Me.tabMain, "tabMain")
        Me.tabMain.Controls.Add(Me.tabStats)
        Me.tabMain.Controls.Add(Me.tabCharts)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        '
        'tabStats
        '
        Me.tabStats.Controls.Add(Me.cboSurveyInfoSession)
        Me.tabStats.Controls.Add(Me.grdSurveyInfo)
        Me.tabStats.Controls.Add(Me.lblSurveyInfoSession)
        resources.ApplyResources(Me.tabStats, "tabStats")
        Me.tabStats.Name = "tabStats"
        Me.tabStats.UseVisualStyleBackColor = True
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
        'tabCharts
        '
        Me.tabCharts.Controls.Add(Me.cboChartType)
        Me.tabCharts.Controls.Add(Me.Label1)
        Me.tabCharts.Controls.Add(Me.chrSessions)
        resources.ApplyResources(Me.tabCharts, "tabCharts")
        Me.tabCharts.Name = "tabCharts"
        Me.tabCharts.UseVisualStyleBackColor = True
        '
        'cboChartType
        '
        Me.cboChartType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboChartType, "cboChartType")
        Me.cboChartType.Items.AddRange(New Object() {resources.GetString("cboChartType.Items"), resources.GetString("cboChartType.Items1"), resources.GetString("cboChartType.Items2"), resources.GetString("cboChartType.Items3"), resources.GetString("cboChartType.Items4"), resources.GetString("cboChartType.Items5")})
        Me.cboChartType.Name = "cboChartType"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'frmInfoSession
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdClose
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.cmdClose)
        Me.MinimizeBox = False
        Me.Name = "frmInfoSession"
        Me.mnuSurveyInfo.ResumeLayout(False)
        CType(Me.chrSessions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.tabStats.ResumeLayout(False)
        Me.tabStats.PerformLayout()
        CType(Me.grdSurveyInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCharts.ResumeLayout(False)
        Me.tabCharts.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cboSurveyInfoSession As System.Windows.Forms.ComboBox
    Friend WithEvents grdSurveyInfo As cSurveyPC.cGrid
    Friend WithEvents lblSurveyInfoSession As System.Windows.Forms.Label
    Friend WithEvents colSurveyInfoName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSurveyInfoValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuSurveyInfo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuSurveyInfoCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSurveyInfoCopyAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chrSessions As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabStats As System.Windows.Forms.TabPage
    Friend WithEvents tabCharts As System.Windows.Forms.TabPage
    Friend WithEvents cboChartType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSurveyInfoExport As System.Windows.Forms.ToolStripMenuItem
End Class
