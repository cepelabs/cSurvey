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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmtest))
        Me.CCaveInfoCombobox1 = New cSurveyPC.cCaveInfoCombobox()
        Me.CCaveInfoBranchesCombobox1 = New cSurveyPC.cCaveInfoBranchesCombobox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SvgImageCollection1 = New DevExpress.Utils.SvgImageCollection(Me.components)
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ImageEdit1 = New DevExpress.XtraEditors.ImageEdit()
        Me.SvgImageBox1 = New DevExpress.XtraEditors.SvgImageBox()
        CType(Me.SvgImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SvgImageBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CCaveInfoCombobox1
        '
        Me.CCaveInfoCombobox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CCaveInfoCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CCaveInfoCombobox1.FormattingEnabled = True
        Me.CCaveInfoCombobox1.Location = New System.Drawing.Point(146, 20)
        Me.CCaveInfoCombobox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CCaveInfoCombobox1.Name = "CCaveInfoCombobox1"
        Me.CCaveInfoCombobox1.Size = New System.Drawing.Size(214, 21)
        Me.CCaveInfoCombobox1.TabIndex = 0
        Me.CCaveInfoCombobox1.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'CCaveInfoBranchesCombobox1
        '
        Me.CCaveInfoBranchesCombobox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CCaveInfoBranchesCombobox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CCaveInfoBranchesCombobox1.FormattingEnabled = True
        Me.CCaveInfoBranchesCombobox1.Location = New System.Drawing.Point(146, 48)
        Me.CCaveInfoBranchesCombobox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CCaveInfoBranchesCombobox1.Name = "CCaveInfoBranchesCombobox1"
        Me.CCaveInfoBranchesCombobox1.Size = New System.Drawing.Size(252, 21)
        Me.CCaveInfoBranchesCombobox1.TabIndex = 1
        Me.CCaveInfoBranchesCombobox1.Workmode = cSurveyPC.cCaveInfoCombobox.WorkmodeEnum.View
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(18, 291)
        Me.RadioButton1.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(90, 17)
        Me.RadioButton1.TabIndex = 2
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "RadioButton1"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(113, 291)
        Me.RadioButton2.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(90, 17)
        Me.RadioButton2.TabIndex = 3
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "RadioButton2"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(337, 293)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        '
        'ImageEdit1
        '
        Me.ImageEdit1.EditValue = Global.cSurveyPC.My.Resources.Resources.error1
        Me.ImageEdit1.Location = New System.Drawing.Point(414, 103)
        Me.ImageEdit1.Name = "ImageEdit1"
        Me.ImageEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ImageEdit1.Size = New System.Drawing.Size(107, 20)
        Me.ImageEdit1.TabIndex = 6
        '
        'SvgImageBox1
        '
        Me.SvgImageBox1.Location = New System.Drawing.Point(100, 135)
        Me.SvgImageBox1.Name = "SvgImageBox1"
        Me.SvgImageBox1.Size = New System.Drawing.Size(237, 66)
        Me.SvgImageBox1.SvgImage = Global.cSurveyPC.My.Resources.Resources.actions_add
        Me.SvgImageBox1.TabIndex = 5
        Me.SvgImageBox1.Text = "SvgImageBox1"
        '
        'frmtest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 326)
        Me.Controls.Add(Me.ImageEdit1)
        Me.Controls.Add(Me.SvgImageBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.CCaveInfoBranchesCombobox1)
        Me.Controls.Add(Me.CCaveInfoCombobox1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "frmtest"
        Me.Text = "frmtest"
        CType(Me.SvgImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SvgImageBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CCaveInfoCombobox1 As cCaveInfoCombobox
    Friend WithEvents CCaveInfoBranchesCombobox1 As cCaveInfoBranchesCombobox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents SvgImageCollection1 As DevExpress.Utils.SvgImageCollection
    Friend WithEvents SvgImageBox1 As DevExpress.XtraEditors.SvgImageBox
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents ImageEdit1 As DevExpress.XtraEditors.ImageEdit
End Class
