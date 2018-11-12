<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClipartPopup
    Inherits cDockContentWindow

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClipartPopup))
        Me.iml = New System.Windows.Forms.ImageList(Me.components)
        Me.tipDefault = New System.Windows.Forms.ToolTip(Me.components)
        Me.mnuLvContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuLvContextOpenFolder = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLvContextRemove = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLvContextEditMetadata = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuLvContextRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.tabGallery = New System.Windows.Forms.TabControl()
        Me.tableMetadata = New System.Windows.Forms.TableLayoutPanel()
        Me.prpMetadataProperties = New System.Windows.Forms.PropertyGrid()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtMetadataClipartFilename = New System.Windows.Forms.TextBox()
        Me.lblMetadataClipartFilename = New System.Windows.Forms.Label()
        Me.txtMetadataClipartName = New System.Windows.Forms.TextBox()
        Me.lblMetadataClipartName = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRemove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnViewGallery = New System.Windows.Forms.ToolStripButton()
        Me.btnViewSurvey = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnShowMetadata = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.mnuLvContext.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.tableMetadata.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'iml
        '
        Me.iml.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit
        resources.ApplyResources(Me.iml, "iml")
        Me.iml.TransparentColor = System.Drawing.Color.Transparent
        '
        'mnuLvContext
        '
        resources.ApplyResources(Me.mnuLvContext, "mnuLvContext")
        Me.mnuLvContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuLvContextOpenFolder, Me.ToolStripMenuItem3, Me.mnuLvContextRemove, Me.ToolStripMenuItem1, Me.mnuLvContextEditMetadata, Me.ToolStripMenuItem2, Me.mnuLvContextRefresh})
        Me.mnuLvContext.Name = "mnuLvContext"
        '
        'mnuLvContextOpenFolder
        '
        Me.mnuLvContextOpenFolder.Name = "mnuLvContextOpenFolder"
        resources.ApplyResources(Me.mnuLvContextOpenFolder, "mnuLvContextOpenFolder")
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'mnuLvContextRemove
        '
        Me.mnuLvContextRemove.Image = Global.cSurveyPC.My.Resources.Resources.cross
        Me.mnuLvContextRemove.Name = "mnuLvContextRemove"
        resources.ApplyResources(Me.mnuLvContextRemove, "mnuLvContextRemove")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuLvContextEditMetadata
        '
        Me.mnuLvContextEditMetadata.Name = "mnuLvContextEditMetadata"
        resources.ApplyResources(Me.mnuLvContextEditMetadata, "mnuLvContextEditMetadata")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuLvContextRefresh
        '
        Me.mnuLvContextRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh_small
        Me.mnuLvContextRefresh.Name = "mnuLvContextRefresh"
        resources.ApplyResources(Me.mnuLvContextRefresh, "mnuLvContextRefresh")
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.SystemColors.Window
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.tabGallery)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.tableMetadata)
        '
        'tabGallery
        '
        resources.ApplyResources(Me.tabGallery, "tabGallery")
        Me.tabGallery.Name = "tabGallery"
        Me.tabGallery.SelectedIndex = 0
        '
        'tableMetadata
        '
        resources.ApplyResources(Me.tableMetadata, "tableMetadata")
        Me.tableMetadata.Controls.Add(Me.prpMetadataProperties, 0, 1)
        Me.tableMetadata.Controls.Add(Me.Panel1, 0, 0)
        Me.tableMetadata.Name = "tableMetadata"
        '
        'prpMetadataProperties
        '
        Me.prpMetadataProperties.CommandsVisibleIfAvailable = False
        resources.ApplyResources(Me.prpMetadataProperties, "prpMetadataProperties")
        Me.prpMetadataProperties.LineColor = System.Drawing.SystemColors.ControlDark
        Me.prpMetadataProperties.Name = "prpMetadataProperties"
        Me.prpMetadataProperties.ToolbarVisible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtMetadataClipartFilename)
        Me.Panel1.Controls.Add(Me.lblMetadataClipartFilename)
        Me.Panel1.Controls.Add(Me.txtMetadataClipartName)
        Me.Panel1.Controls.Add(Me.lblMetadataClipartName)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'txtMetadataClipartFilename
        '
        resources.ApplyResources(Me.txtMetadataClipartFilename, "txtMetadataClipartFilename")
        Me.txtMetadataClipartFilename.Name = "txtMetadataClipartFilename"
        Me.txtMetadataClipartFilename.ReadOnly = True
        '
        'lblMetadataClipartFilename
        '
        resources.ApplyResources(Me.lblMetadataClipartFilename, "lblMetadataClipartFilename")
        Me.lblMetadataClipartFilename.Name = "lblMetadataClipartFilename"
        '
        'txtMetadataClipartName
        '
        resources.ApplyResources(Me.txtMetadataClipartName, "txtMetadataClipartName")
        Me.txtMetadataClipartName.Name = "txtMetadataClipartName"
        Me.txtMetadataClipartName.ReadOnly = True
        '
        'lblMetadataClipartName
        '
        resources.ApplyResources(Me.lblMetadataClipartName, "lblMetadataClipartName")
        Me.lblMetadataClipartName.Name = "lblMetadataClipartName"
        '
        'PictureBox1
        '
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnRemove, Me.ToolStripSeparator2, Me.btnViewGallery, Me.btnViewSurvey, Me.ToolStripSeparator3, Me.btnShowMetadata, Me.ToolStripSeparator4, Me.btnRefresh})
        Me.tbMain.Name = "tbMain"
        '
        'btnAdd
        '
        Me.btnAdd.Image = Global.cSurveyPC.My.Resources.Resources.pencil_go
        resources.ApplyResources(Me.btnAdd, "btnAdd")
        Me.btnAdd.Name = "btnAdd"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'btnRemove
        '
        Me.btnRemove.Image = Global.cSurveyPC.My.Resources.Resources.cross
        resources.ApplyResources(Me.btnRemove, "btnRemove")
        Me.btnRemove.Name = "btnRemove"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'btnViewGallery
        '
        Me.btnViewGallery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewGallery.Image = Global.cSurveyPC.My.Resources.Resources.application_view_gallery
        resources.ApplyResources(Me.btnViewGallery, "btnViewGallery")
        Me.btnViewGallery.Name = "btnViewGallery"
        '
        'btnViewSurvey
        '
        Me.btnViewSurvey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnViewSurvey.Image = Global.cSurveyPC.My.Resources.Resources.application_view_icons
        resources.ApplyResources(Me.btnViewSurvey, "btnViewSurvey")
        Me.btnViewSurvey.Name = "btnViewSurvey"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'btnShowMetadata
        '
        Me.btnShowMetadata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnShowMetadata.Image = Global.cSurveyPC.My.Resources.Resources.application_side_boxes_reversed
        resources.ApplyResources(Me.btnShowMetadata, "btnShowMetadata")
        Me.btnShowMetadata.Name = "btnShowMetadata"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'btnRefresh
        '
        Me.btnRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        resources.ApplyResources(Me.btnRefresh, "btnRefresh")
        Me.btnRefresh.Name = "btnRefresh"
        '
        'frmClipartPopup
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.tbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmClipartPopup"
        Me.ShowInTaskbar = False
        Me.mnuLvContext.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.tableMetadata.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents iml As System.Windows.Forms.ImageList
    Friend WithEvents tipDefault As System.Windows.Forms.ToolTip
    Friend WithEvents tbMain As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRemove As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabGallery As System.Windows.Forms.TabControl
    Friend WithEvents mnuLvContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuLvContextRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLvContextRemove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnViewGallery As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnViewSurvey As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents tableMetadata As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents mnuLvContextEditMetadata As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnShowMetadata As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtMetadataClipartName As System.Windows.Forms.TextBox
    Friend WithEvents lblMetadataClipartName As System.Windows.Forms.Label
    Friend WithEvents txtMetadataClipartFilename As System.Windows.Forms.TextBox
    Friend WithEvents lblMetadataClipartFilename As System.Windows.Forms.Label
    Friend WithEvents prpMetadataProperties As System.Windows.Forms.PropertyGrid
    Friend WithEvents mnuLvContextOpenFolder As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
End Class
