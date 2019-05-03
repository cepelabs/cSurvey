<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmWarpingDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmWarpingDetails))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.chkDontShowWarpingDetails = New System.Windows.Forms.CheckBox()
        Me.grdStations = New cSurveyPC.cGrid()
        Me.colFrom = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeltaSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeltaX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeltaY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeltaAngle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdCancelAndPause = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.grdStations, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdCancel.Image = Global.cSurveyPC.My.Resources.Resources.control_stop_blue
        Me.cmdCancel.Name = "cmdCancel"
        Me.ToolTip.SetToolTip(Me.cmdCancel, resources.GetString("cmdCancel.ToolTip"))
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkDontShowWarpingDetails
        '
        resources.ApplyResources(Me.chkDontShowWarpingDetails, "chkDontShowWarpingDetails")
        Me.chkDontShowWarpingDetails.Name = "chkDontShowWarpingDetails"
        Me.chkDontShowWarpingDetails.UseVisualStyleBackColor = True
        '
        'grdStations
        '
        Me.grdStations.AllowUserToAddRows = False
        Me.grdStations.AllowUserToDeleteRows = False
        Me.grdStations.AllowUserToResizeRows = False
        resources.ApplyResources(Me.grdStations, "grdStations")
        Me.grdStations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdStations.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFrom, Me.colTo, Me.colDeltaSize, Me.colDeltaX, Me.colDeltaY, Me.colDeltaAngle})
        Me.grdStations.Name = "grdStations"
        Me.grdStations.RowHeadersVisible = False
        '
        'colFrom
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colFrom.DefaultCellStyle = DataGridViewCellStyle1
        Me.colFrom.Frozen = True
        resources.ApplyResources(Me.colFrom, "colFrom")
        Me.colFrom.Name = "colFrom"
        Me.colFrom.ReadOnly = True
        '
        'colTo
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colTo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTo.Frozen = True
        resources.ApplyResources(Me.colTo, "colTo")
        Me.colTo.Name = "colTo"
        Me.colTo.ReadOnly = True
        '
        'colDeltaSize
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N3"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colDeltaSize.DefaultCellStyle = DataGridViewCellStyle3
        resources.ApplyResources(Me.colDeltaSize, "colDeltaSize")
        Me.colDeltaSize.Name = "colDeltaSize"
        Me.colDeltaSize.ReadOnly = True
        '
        'colDeltaX
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N3"
        Me.colDeltaX.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.colDeltaX, "colDeltaX")
        Me.colDeltaX.Name = "colDeltaX"
        Me.colDeltaX.ReadOnly = True
        '
        'colDeltaY
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N3"
        Me.colDeltaY.DefaultCellStyle = DataGridViewCellStyle5
        resources.ApplyResources(Me.colDeltaY, "colDeltaY")
        Me.colDeltaY.Name = "colDeltaY"
        Me.colDeltaY.ReadOnly = True
        '
        'colDeltaAngle
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N3"
        Me.colDeltaAngle.DefaultCellStyle = DataGridViewCellStyle6
        resources.ApplyResources(Me.colDeltaAngle, "colDeltaAngle")
        Me.colDeltaAngle.Name = "colDeltaAngle"
        Me.colDeltaAngle.ReadOnly = True
        '
        'cmdCancelAndPause
        '
        resources.ApplyResources(Me.cmdCancelAndPause, "cmdCancelAndPause")
        Me.cmdCancelAndPause.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdCancelAndPause.Image = Global.cSurveyPC.My.Resources.Resources.control_pause_blue
        Me.cmdCancelAndPause.Name = "cmdCancelAndPause"
        Me.ToolTip.SetToolTip(Me.cmdCancelAndPause, resources.GetString("cmdCancelAndPause.ToolTip"))
        Me.cmdCancelAndPause.UseVisualStyleBackColor = True
        '
        'frmWarpingDetails
        '
        Me.AcceptButton = Me.cmdApply
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cmdCancelAndPause)
        Me.Controls.Add(Me.chkDontShowWarpingDetails)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.grdStations)
        Me.MinimizeBox = False
        Me.Name = "frmWarpingDetails"
        CType(Me.grdStations, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grdStations As cGrid
    Friend WithEvents cmdApply As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents colFrom As DataGridViewTextBoxColumn
    Friend WithEvents colTo As DataGridViewTextBoxColumn
    Friend WithEvents colDeltaSize As DataGridViewTextBoxColumn
    Friend WithEvents colDeltaX As DataGridViewTextBoxColumn
    Friend WithEvents colDeltaY As DataGridViewTextBoxColumn
    Friend WithEvents colDeltaAngle As DataGridViewTextBoxColumn
    Friend WithEvents chkDontShowWarpingDetails As CheckBox
    Friend WithEvents cmdCancelAndPause As Button
    Friend WithEvents ToolTip As ToolTip
End Class
