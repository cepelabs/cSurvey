<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoOrientation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoOrientation))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.chrtBearings = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.pnlSurveyInfo = New System.Windows.Forms.Panel()
        Me.chkShowCaveDistinct = New System.Windows.Forms.CheckBox()
        Me.cboSurveyInfoCave = New System.Windows.Forms.ComboBox()
        Me.lblSurveyInfoCave = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.picNord = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdDecMagValues = New cSurveyPC.cGrid()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grdNordInfo = New cSurveyPC.cGrid()
        Me.colSurveyInfoName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSurveyInfoValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.chrtBearings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSurveyInfo.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.picNord, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDecMagValues, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdNordInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'chrtBearings
        '
        resources.ApplyResources(Me.chrtBearings, "chrtBearings")
        Me.chrtBearings.BackColor = System.Drawing.SystemColors.Window
        ChartArea1.AlignmentOrientation = CType((System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Vertical Or System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations.Horizontal), System.Windows.Forms.DataVisualization.Charting.AreaAlignmentOrientations)
        ChartArea1.AlignmentStyle = System.Windows.Forms.DataVisualization.Charting.AreaAlignmentStyles.None
        ChartArea1.Area3DStyle.LightStyle = System.Windows.Forms.DataVisualization.Charting.LightStyle.Realistic
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisX2.IsLabelAutoFit = False
        ChartArea1.AxisX2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY.IsLabelAutoFit = False
        ChartArea1.AxisY.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.AxisY2.IsLabelAutoFit = False
        ChartArea1.AxisY2.TitleFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ChartArea1.IsSameFontSizeForAllAxes = True
        ChartArea1.Name = "ChartArea1"
        ChartArea1.ShadowColor = System.Drawing.Color.DimGray
        ChartArea1.ShadowOffset = 1
        Me.chrtBearings.ChartAreas.Add(ChartArea1)
        Me.chrtBearings.Name = "chrtBearings"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Polar
        Series1.Color = System.Drawing.Color.Salmon
        Series1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Series1.Legend = "Legend1"
        Series1.Name = "Segments"
        Me.chrtBearings.Series.Add(Series1)
        Me.chrtBearings.SuppressExceptions = True
        Title1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Title1.Name = "Title1"
        Title1.Text = "Bearing"
        Me.chrtBearings.Titles.Add(Title1)
        '
        'pnlSurveyInfo
        '
        Me.pnlSurveyInfo.BackColor = System.Drawing.SystemColors.Window
        Me.pnlSurveyInfo.Controls.Add(Me.chkShowCaveDistinct)
        Me.pnlSurveyInfo.Controls.Add(Me.chrtBearings)
        Me.pnlSurveyInfo.Controls.Add(Me.cboSurveyInfoCave)
        Me.pnlSurveyInfo.Controls.Add(Me.lblSurveyInfoCave)
        resources.ApplyResources(Me.pnlSurveyInfo, "pnlSurveyInfo")
        Me.pnlSurveyInfo.Name = "pnlSurveyInfo"
        '
        'chkShowCaveDistinct
        '
        resources.ApplyResources(Me.chkShowCaveDistinct, "chkShowCaveDistinct")
        Me.chkShowCaveDistinct.Name = "chkShowCaveDistinct"
        Me.chkShowCaveDistinct.UseVisualStyleBackColor = True
        '
        'cboSurveyInfoCave
        '
        Me.cboSurveyInfoCave.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSurveyInfoCave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSurveyInfoCave, "cboSurveyInfoCave")
        Me.cboSurveyInfoCave.Name = "cboSurveyInfoCave"
        '
        'lblSurveyInfoCave
        '
        resources.ApplyResources(Me.lblSurveyInfoCave, "lblSurveyInfoCave")
        Me.lblSurveyInfoCave.Name = "lblSurveyInfoCave"
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.pnlSurveyInfo)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.picNord)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.grdDecMagValues)
        Me.TabPage2.Controls.Add(Me.grdNordInfo)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'picNord
        '
        resources.ApplyResources(Me.picNord, "picNord")
        Me.picNord.Name = "picNord"
        Me.picNord.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'grdDecMagValues
        '
        Me.grdDecMagValues.AllowUserToAddRows = False
        Me.grdDecMagValues.AllowUserToDeleteRows = False
        Me.grdDecMagValues.AllowUserToResizeRows = False
        resources.ApplyResources(Me.grdDecMagValues, "grdDecMagValues")
        Me.grdDecMagValues.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdDecMagValues.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdDecMagValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDecMagValues.ColumnHeadersVisible = False
        Me.grdDecMagValues.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.grdDecMagValues.Name = "grdDecMagValues"
        Me.grdDecMagValues.ReadOnly = True
        Me.grdDecMagValues.RowHeadersVisible = False
        Me.grdDecMagValues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDecMagValues.ShowEditingIcon = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.FillWeight = 37.5!
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.FillWeight = 62.5!
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'grdNordInfo
        '
        Me.grdNordInfo.AllowUserToAddRows = False
        Me.grdNordInfo.AllowUserToDeleteRows = False
        Me.grdNordInfo.AllowUserToResizeRows = False
        resources.ApplyResources(Me.grdNordInfo, "grdNordInfo")
        Me.grdNordInfo.BackgroundColor = System.Drawing.SystemColors.Window
        Me.grdNordInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdNordInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdNordInfo.ColumnHeadersVisible = False
        Me.grdNordInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSurveyInfoName, Me.colSurveyInfoValue})
        Me.grdNordInfo.Name = "grdNordInfo"
        Me.grdNordInfo.ReadOnly = True
        Me.grdNordInfo.RowHeadersVisible = False
        Me.grdNordInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdNordInfo.ShowEditingIcon = False
        '
        'colSurveyInfoName
        '
        Me.colSurveyInfoName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSurveyInfoName.FillWeight = 37.5!
        resources.ApplyResources(Me.colSurveyInfoName, "colSurveyInfoName")
        Me.colSurveyInfoName.Name = "colSurveyInfoName"
        Me.colSurveyInfoName.ReadOnly = True
        '
        'colSurveyInfoValue
        '
        Me.colSurveyInfoValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSurveyInfoValue.FillWeight = 62.5!
        resources.ApplyResources(Me.colSurveyInfoValue, "colSurveyInfoValue")
        Me.colSurveyInfoValue.Name = "colSurveyInfoValue"
        Me.colSurveyInfoValue.ReadOnly = True
        '
        'frmInfoOrientation
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdClose)
        Me.MinimizeBox = False
        Me.Name = "frmInfoOrientation"
        CType(Me.chrtBearings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSurveyInfo.ResumeLayout(False)
        Me.pnlSurveyInfo.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.picNord, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDecMagValues, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdNordInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents chrtBearings As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents pnlSurveyInfo As System.Windows.Forms.Panel
    Friend WithEvents cboSurveyInfoCave As System.Windows.Forms.ComboBox
    Friend WithEvents lblSurveyInfoCave As System.Windows.Forms.Label
    Friend WithEvents chkShowCaveDistinct As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents grdNordInfo As cSurveyPC.cGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grdDecMagValues As cSurveyPC.cGrid
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSurveyInfoName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSurveyInfoValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents picNord As System.Windows.Forms.PictureBox
End Class
