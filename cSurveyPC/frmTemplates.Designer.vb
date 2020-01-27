<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTemplates
    Inherits cForm

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTemplates))
        Me.lvTemplates = New BrightIdeasSoftware.DataListView()
        Me.colName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colDefault = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.mnuTemplates = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTemplatesDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuTemplatesSetAsDefault = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlName = New System.Windows.Forms.Panel()
        CType(Me.lvTemplates, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuTemplates.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.pnlName.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvTemplates
        '
        Me.lvTemplates.AllColumns.Add(Me.colName)
        Me.lvTemplates.AllColumns.Add(Me.colDefault)
        Me.lvTemplates.AllowDrop = True
        Me.lvTemplates.CellEditUseWholeCell = False
        Me.lvTemplates.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colName, Me.colDefault})
        Me.lvTemplates.ContextMenuStrip = Me.mnuTemplates
        Me.lvTemplates.Cursor = System.Windows.Forms.Cursors.Default
        Me.lvTemplates.DataSource = Nothing
        resources.ApplyResources(Me.lvTemplates, "lvTemplates")
        Me.lvTemplates.FullRowSelect = True
        Me.lvTemplates.HideSelection = False
        Me.lvTemplates.Name = "lvTemplates"
        Me.lvTemplates.UseCompatibleStateImageBehavior = False
        Me.lvTemplates.View = System.Windows.Forms.View.Details
        '
        'colName
        '
        Me.colName.FillsFreeSpace = True
        Me.colName.Groupable = False
        Me.colName.IsEditable = False
        resources.ApplyResources(Me.colName, "colName")
        '
        'colDefault
        '
        Me.colDefault.CheckBoxes = True
        resources.ApplyResources(Me.colDefault, "colDefault")
        '
        'mnuTemplates
        '
        resources.ApplyResources(Me.mnuTemplates, "mnuTemplates")
        Me.mnuTemplates.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuTemplatesDelete, Me.ToolStripMenuItem1, Me.mnuTemplatesSetAsDefault})
        Me.mnuTemplates.Name = "mnuTemplates"
        '
        'mnuTemplatesDelete
        '
        Me.mnuTemplatesDelete.Name = "mnuTemplatesDelete"
        resources.ApplyResources(Me.mnuTemplatesDelete, "mnuTemplatesDelete")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuTemplatesSetAsDefault
        '
        Me.mnuTemplatesSetAsDefault.Name = "mnuTemplatesSetAsDefault"
        resources.ApplyResources(Me.mnuTemplatesSetAsDefault, "mnuTemplatesSetAsDefault")
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.cmdClose)
        Me.pnlBottom.Controls.Add(Me.cmdCancel)
        Me.pnlBottom.Controls.Add(Me.cmdOk)
        resources.ApplyResources(Me.pnlBottom, "pnlBottom")
        Me.pnlBottom.Name = "pnlBottom"
        '
        'cmdClose
        '
        resources.ApplyResources(Me.cmdClose, "cmdClose")
        Me.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.UseVisualStyleBackColor = True
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
        'txtName
        '
        resources.ApplyResources(Me.txtName, "txtName")
        Me.txtName.Name = "txtName"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'pnlName
        '
        Me.pnlName.Controls.Add(Me.txtName)
        Me.pnlName.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.pnlName, "pnlName")
        Me.pnlName.Name = "pnlName"
        '
        'frmTemplates
        '
        Me.AcceptButton = Me.cmdOk
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.Controls.Add(Me.pnlName)
        Me.Controls.Add(Me.lvTemplates)
        Me.Controls.Add(Me.pnlBottom)
        Me.MinimizeBox = False
        Me.Name = "frmTemplates"
        CType(Me.lvTemplates, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuTemplates.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlName.ResumeLayout(False)
        Me.pnlName.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvTemplates As BrightIdeasSoftware.DataListView
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents cmdCancel As Button
    Friend WithEvents cmdOk As Button
    Friend WithEvents txtName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents colName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents mnuTemplates As ContextMenuStrip
    Friend WithEvents mnuTemplatesDelete As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuTemplatesSetAsDefault As ToolStripMenuItem
    Friend WithEvents colDefault As BrightIdeasSoftware.OLVColumn
    Friend WithEvents pnlName As Panel
    Friend WithEvents cmdClose As Button
End Class
