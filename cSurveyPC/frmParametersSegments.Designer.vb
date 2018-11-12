<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParametersSegments
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmParametersSegments))
        Me.cmdApply = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkDuplicate = New System.Windows.Forms.CheckBox()
        Me.chkSurface = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cboSegmentsPaintStyle = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboSplayStyle = New System.Windows.Forms.ComboBox()
        Me.lblSplayStyle = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lvDesignPlotShowHLsDett = New System.Windows.Forms.ListView()
        Me.colNome = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chkShowHLs = New System.Windows.Forms.CheckBox()
        Me.chkDesignSurfaceProfile = New System.Windows.Forms.CheckBox()
        Me.grpSurface = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.grpSurface.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdApply
        '
        resources.ApplyResources(Me.cmdApply, "cmdApply")
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        resources.ApplyResources(Me.cmdOk, "cmdOk")
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        resources.ApplyResources(Me.cmdCancel, "cmdCancel")
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.chkDuplicate)
        Me.GroupBox1.Controls.Add(Me.chkSurface)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'chkDuplicate
        '
        resources.ApplyResources(Me.chkDuplicate, "chkDuplicate")
        Me.chkDuplicate.Name = "chkDuplicate"
        Me.chkDuplicate.UseVisualStyleBackColor = True
        '
        'chkSurface
        '
        resources.ApplyResources(Me.chkSurface, "chkSurface")
        Me.chkSurface.Name = "chkSurface"
        Me.chkSurface.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Controls.Add(Me.cboSegmentsPaintStyle)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'cboSegmentsPaintStyle
        '
        Me.cboSegmentsPaintStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.cboSegmentsPaintStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSegmentsPaintStyle.Items.AddRange(New Object() {resources.GetString("cboSegmentsPaintStyle.Items"), resources.GetString("cboSegmentsPaintStyle.Items1"), resources.GetString("cboSegmentsPaintStyle.Items2"), resources.GetString("cboSegmentsPaintStyle.Items3")})
        resources.ApplyResources(Me.cboSegmentsPaintStyle, "cboSegmentsPaintStyle")
        Me.cboSegmentsPaintStyle.Name = "cboSegmentsPaintStyle"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cboSplayStyle
        '
        Me.cboSplayStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboSplayStyle, "cboSplayStyle")
        Me.cboSplayStyle.Items.AddRange(New Object() {resources.GetString("cboSplayStyle.Items"), resources.GetString("cboSplayStyle.Items1")})
        Me.cboSplayStyle.Name = "cboSplayStyle"
        '
        'lblSplayStyle
        '
        resources.ApplyResources(Me.lblSplayStyle, "lblSplayStyle")
        Me.lblSplayStyle.Name = "lblSplayStyle"
        '
        'GroupBox3
        '
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Controls.Add(Me.cboSplayStyle)
        Me.GroupBox3.Controls.Add(Me.lblSplayStyle)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Controls.Add(Me.lvDesignPlotShowHLsDett)
        Me.GroupBox4.Controls.Add(Me.chkShowHLs)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'lvDesignPlotShowHLsDett
        '
        resources.ApplyResources(Me.lvDesignPlotShowHLsDett, "lvDesignPlotShowHLsDett")
        Me.lvDesignPlotShowHLsDett.CheckBoxes = True
        Me.lvDesignPlotShowHLsDett.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colNome})
        Me.lvDesignPlotShowHLsDett.FullRowSelect = True
        Me.lvDesignPlotShowHLsDett.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvDesignPlotShowHLsDett.HideSelection = False
        Me.lvDesignPlotShowHLsDett.Name = "lvDesignPlotShowHLsDett"
        Me.lvDesignPlotShowHLsDett.UseCompatibleStateImageBehavior = False
        Me.lvDesignPlotShowHLsDett.View = System.Windows.Forms.View.Details
        '
        'colNome
        '
        resources.ApplyResources(Me.colNome, "colNome")
        '
        'chkShowHLs
        '
        resources.ApplyResources(Me.chkShowHLs, "chkShowHLs")
        Me.chkShowHLs.Name = "chkShowHLs"
        Me.chkShowHLs.UseVisualStyleBackColor = True
        '
        'chkDesignSurfaceProfile
        '
        resources.ApplyResources(Me.chkDesignSurfaceProfile, "chkDesignSurfaceProfile")
        Me.chkDesignSurfaceProfile.Name = "chkDesignSurfaceProfile"
        Me.chkDesignSurfaceProfile.UseVisualStyleBackColor = True
        '
        'grpSurface
        '
        resources.ApplyResources(Me.grpSurface, "grpSurface")
        Me.grpSurface.Controls.Add(Me.chkDesignSurfaceProfile)
        Me.grpSurface.Name = "grpSurface"
        Me.grpSurface.TabStop = False
        '
        'frmParametersSegments
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.grpSurface)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdApply)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmParametersSegments"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.grpSurface.ResumeLayout(False)
        Me.grpSurface.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdApply As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDuplicate As System.Windows.Forms.CheckBox
    Friend WithEvents chkSurface As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboSegmentsPaintStyle As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSplayStyle As System.Windows.Forms.ComboBox
    Friend WithEvents lblSplayStyle As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowHLs As System.Windows.Forms.CheckBox
    Friend WithEvents lvDesignPlotShowHLsDett As ListView
    Friend WithEvents colNome As ColumnHeader
    Friend WithEvents chkDesignSurfaceProfile As CheckBox
    Friend WithEvents grpSurface As GroupBox
End Class
