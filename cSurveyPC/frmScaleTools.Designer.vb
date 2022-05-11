<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScaleTools
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScaleTools))
        Me.txtScale = New System.Windows.Forms.NumericUpDown()
        Me.lblScale1 = New System.Windows.Forms.Label()
        Me.lblScale = New System.Windows.Forms.Label()
        Me.lv = New System.Windows.Forms.ListView()
        Me.colSegmentInfoName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSegmentInfoValue = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdCalculate = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        CType(Me.txtScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtScale
        '
        Me.txtScale.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        resources.ApplyResources(Me.txtScale, "txtScale")
        Me.txtScale.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.txtScale.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtScale.Name = "txtScale"
        Me.txtScale.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblScale1
        '
        resources.ApplyResources(Me.lblScale1, "lblScale1")
        Me.lblScale1.Name = "lblScale1"
        '
        'lblScale
        '
        resources.ApplyResources(Me.lblScale, "lblScale")
        Me.lblScale.Name = "lblScale"
        '
        'lv
        '
        Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colSegmentInfoName, Me.colSegmentInfoValue})
        Me.lv.FullRowSelect = True
        Me.lv.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {CType(resources.GetObject("lv.Groups"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("lv.Groups1"), System.Windows.Forms.ListViewGroup), CType(resources.GetObject("lv.Groups2"), System.Windows.Forms.ListViewGroup)})
        Me.lv.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lv.HideSelection = False
        resources.ApplyResources(Me.lv, "lv")
        Me.lv.Name = "lv"
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.Details
        '
        'colSegmentInfoName
        '
        resources.ApplyResources(Me.colSegmentInfoName, "colSegmentInfoName")
        '
        'colSegmentInfoValue
        '
        resources.ApplyResources(Me.colSegmentInfoValue, "colSegmentInfoValue")
        '
        'cmdCalculate
        '
        resources.ApplyResources(Me.cmdCalculate, "cmdCalculate")
        Me.cmdCalculate.Name = "cmdCalculate"
        Me.cmdCalculate.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'frmScaleTools
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdCalculate)
        Me.Controls.Add(Me.lv)
        Me.Controls.Add(Me.txtScale)
        Me.Controls.Add(Me.lblScale1)
        Me.Controls.Add(Me.lblScale)
        Me.IconOptions.Icon = CType(resources.GetObject("frmScaleTools.IconOptions.Icon"), System.Drawing.Icon)
        Me.IconOptions.SvgImage = Global.cSurveyPC.My.Resources.Resources.icon_scale
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScaleTools"
        CType(Me.txtScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblScale1 As System.Windows.Forms.Label
    Friend WithEvents lblScale As System.Windows.Forms.Label
    Friend WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents colSegmentInfoName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSegmentInfoValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdCalculate As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
End Class
