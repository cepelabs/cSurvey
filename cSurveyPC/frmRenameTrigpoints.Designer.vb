<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRenameTrigpoints
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRenameTrigpoints))
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cboOld = New System.Windows.Forms.ComboBox()
        Me.lblOldTrigPoint = New System.Windows.Forms.Label()
        Me.lblNewTrigPoint = New System.Windows.Forms.Label()
        Me.txtNew = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
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
        'cboOld
        '
        Me.cboOld.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOld.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        resources.ApplyResources(Me.cboOld, "cboOld")
        Me.cboOld.Name = "cboOld"
        '
        'lblOldTrigPoint
        '
        resources.ApplyResources(Me.lblOldTrigPoint, "lblOldTrigPoint")
        Me.lblOldTrigPoint.Name = "lblOldTrigPoint"
        '
        'lblNewTrigPoint
        '
        resources.ApplyResources(Me.lblNewTrigPoint, "lblNewTrigPoint")
        Me.lblNewTrigPoint.Name = "lblNewTrigPoint"
        '
        'txtNew
        '
        resources.ApplyResources(Me.txtNew, "txtNew")
        Me.txtNew.Name = "txtNew"
        '
        'frmRenameTrigpoints
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.txtNew)
        Me.Controls.Add(Me.lblNewTrigPoint)
        Me.Controls.Add(Me.cboOld)
        Me.Controls.Add(Me.lblOldTrigPoint)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRenameTrigpoints"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cboOld As System.Windows.Forms.ComboBox
    Friend WithEvents lblOldTrigPoint As System.Windows.Forms.Label
    Friend WithEvents lblNewTrigPoint As System.Windows.Forms.Label
    Friend WithEvents txtNew As System.Windows.Forms.TextBox
End Class
