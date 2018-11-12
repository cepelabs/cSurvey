<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreviewMargins
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreviewMargins))
        Me.frmMargins = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRight = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLeft = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBottom = New System.Windows.Forms.TextBox()
        Me.lblTop = New System.Windows.Forms.Label()
        Me.txtTop = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.frmMargins.SuspendLayout()
        Me.SuspendLayout()
        '
        'frmMargins
        '
        resources.ApplyResources(Me.frmMargins, "frmMargins")
        Me.frmMargins.Controls.Add(Me.Label2)
        Me.frmMargins.Controls.Add(Me.txtRight)
        Me.frmMargins.Controls.Add(Me.Label3)
        Me.frmMargins.Controls.Add(Me.txtLeft)
        Me.frmMargins.Controls.Add(Me.Label1)
        Me.frmMargins.Controls.Add(Me.txtBottom)
        Me.frmMargins.Controls.Add(Me.lblTop)
        Me.frmMargins.Controls.Add(Me.txtTop)
        Me.frmMargins.Name = "frmMargins"
        Me.frmMargins.TabStop = False
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'txtRight
        '
        resources.ApplyResources(Me.txtRight, "txtRight")
        Me.txtRight.Name = "txtRight"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'txtLeft
        '
        resources.ApplyResources(Me.txtLeft, "txtLeft")
        Me.txtLeft.Name = "txtLeft"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'txtBottom
        '
        resources.ApplyResources(Me.txtBottom, "txtBottom")
        Me.txtBottom.Name = "txtBottom"
        '
        'lblTop
        '
        resources.ApplyResources(Me.lblTop, "lblTop")
        Me.lblTop.Name = "lblTop"
        '
        'txtTop
        '
        resources.ApplyResources(Me.txtTop, "txtTop")
        Me.txtTop.Name = "txtTop"
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
        'frmPreviewMargins
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.frmMargins)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreviewMargins"
        Me.frmMargins.ResumeLayout(False)
        Me.frmMargins.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frmMargins As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRight As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLeft As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBottom As System.Windows.Forms.TextBox
    Friend WithEvents lblTop As System.Windows.Forms.Label
    Friend WithEvents txtTop As System.Windows.Forms.TextBox
End Class
