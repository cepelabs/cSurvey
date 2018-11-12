<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cItemNamePropertyControl
    Inherits cItemPropertyControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cItemNamePropertyControl))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPropName = New System.Windows.Forms.TextBox()
        Me.lblPropName = New System.Windows.Forms.Label()
        Me.cmdItemNameRegen = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'txtPropName
        '
        resources.ApplyResources(Me.txtPropName, "txtPropName")
        Me.txtPropName.Name = "txtPropName"
        '
        'lblPropName
        '
        resources.ApplyResources(Me.lblPropName, "lblPropName")
        Me.lblPropName.Name = "lblPropName"
        '
        'cmdItemNameRegen
        '
        resources.ApplyResources(Me.cmdItemNameRegen, "cmdItemNameRegen")
        Me.cmdItemNameRegen.Image = Global.cSurveyPC.My.Resources.Resources.stamp_pattern
        Me.cmdItemNameRegen.Name = "cmdItemNameRegen"
        Me.ToolTip.SetToolTip(Me.cmdItemNameRegen, resources.GetString("cmdItemNameRegen.ToolTip"))
        Me.cmdItemNameRegen.UseVisualStyleBackColor = True
        '
        'cItemNamePropertyControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.cmdItemNameRegen)
        Me.Controls.Add(Me.lblPropName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPropName)
        Me.Name = "cItemNamePropertyControl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPropName As TextBox
    Friend WithEvents lblPropName As Label
    Friend WithEvents cmdItemNameRegen As Button
    Friend WithEvents ToolTip As ToolTip
End Class
