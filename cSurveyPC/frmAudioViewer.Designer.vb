<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAudioViewer
    Inherits cDockContentWindow

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAudioViewer))
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.cmdPlay = New System.Windows.Forms.ToolStripButton()
        Me.cmdStop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdExport = New System.Windows.Forms.ToolStripButton()
        Me.tvAttachments = New BrightIdeasSoftware.ObjectListView()
        Me.colAttachmentIcon = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colAttachmentName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colAttachmentNote = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colAttachmentOwner = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.mnuAttachments = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuAttachmentGotoOwner = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbMain.SuspendLayout()
        CType(Me.tvAttachments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuAttachments.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdPlay, Me.cmdStop, Me.ToolStripSeparator1, Me.cmdExport})
        Me.tbMain.Name = "tbMain"
        '
        'cmdPlay
        '
        Me.cmdPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.cmdPlay, "cmdPlay")
        Me.cmdPlay.Image = Global.cSurveyPC.My.Resources.Resources.control_play_blue
        Me.cmdPlay.Name = "cmdPlay"
        '
        'cmdStop
        '
        Me.cmdStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.cmdStop, "cmdStop")
        Me.cmdStop.Image = Global.cSurveyPC.My.Resources.Resources.control_stop_blue
        Me.cmdStop.Name = "cmdStop"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'cmdExport
        '
        Me.cmdExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.cmdExport, "cmdExport")
        Me.cmdExport.Image = Global.cSurveyPC.My.Resources.Resources.save_as1
        Me.cmdExport.Name = "cmdExport"
        '
        'tvAttachments
        '
        Me.tvAttachments.AllColumns.Add(Me.colAttachmentIcon)
        Me.tvAttachments.AllColumns.Add(Me.colAttachmentName)
        Me.tvAttachments.AllColumns.Add(Me.colAttachmentNote)
        Me.tvAttachments.AllColumns.Add(Me.colAttachmentOwner)
        Me.tvAttachments.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvAttachments.CellEditUseWholeCell = False
        Me.tvAttachments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colAttachmentIcon, Me.colAttachmentName, Me.colAttachmentNote, Me.colAttachmentOwner})
        Me.tvAttachments.ContextMenuStrip = Me.mnuAttachments
        Me.tvAttachments.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.tvAttachments, "tvAttachments")
        Me.tvAttachments.FullRowSelect = True
        Me.tvAttachments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.tvAttachments.HideSelection = False
        Me.tvAttachments.MultiSelect = False
        Me.tvAttachments.Name = "tvAttachments"
        Me.tvAttachments.RowHeight = 32
        Me.tvAttachments.ShowGroups = False
        Me.tvAttachments.ShowImagesOnSubItems = True
        Me.tvAttachments.UseCompatibleStateImageBehavior = False
        Me.tvAttachments.View = System.Windows.Forms.View.Details
        Me.tvAttachments.VirtualMode = True
        '
        'colAttachmentIcon
        '
        Me.colAttachmentIcon.IsEditable = False
        Me.colAttachmentIcon.MaximumWidth = 36
        Me.colAttachmentIcon.MinimumWidth = 36
        resources.ApplyResources(Me.colAttachmentIcon, "colAttachmentIcon")
        '
        'colAttachmentName
        '
        Me.colAttachmentName.IsEditable = False
        resources.ApplyResources(Me.colAttachmentName, "colAttachmentName")
        Me.colAttachmentName.WordWrap = True
        '
        'colAttachmentNote
        '
        Me.colAttachmentNote.IsEditable = False
        resources.ApplyResources(Me.colAttachmentNote, "colAttachmentNote")
        Me.colAttachmentNote.WordWrap = True
        '
        'colAttachmentOwner
        '
        resources.ApplyResources(Me.colAttachmentOwner, "colAttachmentOwner")
        '
        'mnuAttachments
        '
        resources.ApplyResources(Me.mnuAttachments, "mnuAttachments")
        Me.mnuAttachments.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAttachmentGotoOwner})
        Me.mnuAttachments.Name = "mnuAttachments"
        '
        'mnuAttachmentGotoOwner
        '
        Me.mnuAttachmentGotoOwner.Name = "mnuAttachmentGotoOwner"
        resources.ApplyResources(Me.mnuAttachmentGotoOwner, "mnuAttachmentGotoOwner")
        '
        'frmAudioViewer
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.tvAttachments)
        Me.Controls.Add(Me.tbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmAudioViewer"
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        CType(Me.tvAttachments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuAttachments.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbMain As ToolStrip
    Friend WithEvents cmdPlay As ToolStripButton
    Friend WithEvents cmdStop As ToolStripButton
    Friend WithEvents tvAttachments As BrightIdeasSoftware.ObjectListView
    Friend WithEvents colAttachmentIcon As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colAttachmentName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colAttachmentNote As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colAttachmentOwner As BrightIdeasSoftware.OLVColumn
    Friend WithEvents mnuAttachments As ContextMenuStrip
    Friend WithEvents mnuAttachmentGotoOwner As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdExport As ToolStripButton
End Class
