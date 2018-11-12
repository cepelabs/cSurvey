<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmtest
    Inherits System.Windows.Forms.Form

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
        Me.CCaveInfoCombobox1 = New cSurveyPC.cCaveInfoCombobox()
        Me.CCaveInfoBranchesCombobox1 = New cSurveyPC.cCaveInfoBranchesCombobox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'CCaveInfoCombobox1
        '
        Me.CCaveInfoCombobox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CCaveInfoCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CCaveInfoCombobox1.FormattingEnabled = True
        Me.CCaveInfoCombobox1.Location = New System.Drawing.Point(267, 36)
        Me.CCaveInfoCombobox1.Name = "CCaveInfoCombobox1"
        Me.CCaveInfoCombobox1.Size = New System.Drawing.Size(389, 30)
        Me.CCaveInfoCombobox1.TabIndex = 0
        Me.CCaveInfoCombobox1.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'CCaveInfoBranchesCombobox1
        '
        Me.CCaveInfoBranchesCombobox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CCaveInfoBranchesCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CCaveInfoBranchesCombobox1.FormattingEnabled = True
        Me.CCaveInfoBranchesCombobox1.Location = New System.Drawing.Point(267, 88)
        Me.CCaveInfoBranchesCombobox1.Name = "CCaveInfoBranchesCombobox1"
        Me.CCaveInfoBranchesCombobox1.Size = New System.Drawing.Size(458, 30)
        Me.CCaveInfoBranchesCombobox1.TabIndex = 1
        Me.CCaveInfoBranchesCombobox1.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(33, 538)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(154, 29)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "RadioButton1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(207, 538)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(154, 29)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(618, 540)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(140, 29)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'frmtest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 601)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.CCaveInfoBranchesCombobox1)
        Me.Controls.Add(Me.CCaveInfoCombobox1)
        Me.Name = "frmtest"
        Me.Text = "frmtest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CCaveInfoCombobox1 As cCaveInfoCombobox
    Friend WithEvents CCaveInfoBranchesCombobox1 As cCaveInfoBranchesCombobox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents CheckBox1 As CheckBox
End Class
