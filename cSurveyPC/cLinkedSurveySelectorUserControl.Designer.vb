<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cLinkedSurveySelectorControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(cLinkedSurveySelectorControl))
        Me.tvLinkedSurveys = New BrightIdeasSoftware.ObjectListView()
        Me.colLinkedSurveysIcon = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysGPS = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysFilename = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuContextDeselectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextRefresh = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvLinkedSurveys
        '
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysIcon)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysGPS)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysName)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysFilename)
        Me.tvLinkedSurveys.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvLinkedSurveys.CellEditUseWholeCell = False
        Me.tvLinkedSurveys.CheckBoxes = True
        Me.tvLinkedSurveys.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLinkedSurveysIcon, Me.colLinkedSurveysGPS, Me.colLinkedSurveysName, Me.colLinkedSurveysFilename})
        Me.tvLinkedSurveys.ContextMenuStrip = Me.mnuContext
        Me.tvLinkedSurveys.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.tvLinkedSurveys, "tvLinkedSurveys")
        Me.tvLinkedSurveys.FullRowSelect = True
        Me.tvLinkedSurveys.HideSelection = False
        Me.tvLinkedSurveys.Name = "tvLinkedSurveys"
        Me.tvLinkedSurveys.ShowGroups = False
        Me.tvLinkedSurveys.ShowImagesOnSubItems = True
        Me.tvLinkedSurveys.UseCompatibleStateImageBehavior = False
        Me.tvLinkedSurveys.View = System.Windows.Forms.View.Details
        Me.tvLinkedSurveys.VirtualMode = True
        '
        'colLinkedSurveysIcon
        '
        Me.colLinkedSurveysIcon.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysIcon, "colLinkedSurveysIcon")
        '
        'colLinkedSurveysGPS
        '
        Me.colLinkedSurveysGPS.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysGPS, "colLinkedSurveysGPS")
        '
        'colLinkedSurveysName
        '
        Me.colLinkedSurveysName.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysName, "colLinkedSurveysName")
        '
        'colLinkedSurveysFilename
        '
        Me.colLinkedSurveysFilename.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysFilename, "colLinkedSurveysFilename")
        '
        'mnuContext
        '
        resources.ApplyResources(Me.mnuContext, "mnuContext")
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextSelectAll, Me.mnuContextDeselectAll, Me.ToolStripMenuItem1, Me.mnuContextRefresh})
        Me.mnuContext.Name = "mnuContext"
        '
        'mnuContextSelectAll
        '
        Me.mnuContextSelectAll.Name = "mnuContextSelectAll"
        resources.ApplyResources(Me.mnuContextSelectAll, "mnuContextSelectAll")
        '
        'mnuContextDeselectAll
        '
        Me.mnuContextDeselectAll.Name = "mnuContextDeselectAll"
        resources.ApplyResources(Me.mnuContextDeselectAll, "mnuContextDeselectAll")
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnuContextRefresh
        '
        Me.mnuContextRefresh.Name = "mnuContextRefresh"
        resources.ApplyResources(Me.mnuContextRefresh, "mnuContextRefresh")
        '
        'cLinkedSurveySelectorControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tvLinkedSurveys)
        Me.Name = "cLinkedSurveySelectorControl"
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContext.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tvLinkedSurveys As BrightIdeasSoftware.ObjectListView
    Friend WithEvents colLinkedSurveysIcon As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysGPS As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysFilename As BrightIdeasSoftware.OLVColumn
    Friend WithEvents mnuContext As ContextMenuStrip
    Friend WithEvents mnuContextSelectAll As ToolStripMenuItem
    Friend WithEvents mnuContextDeselectAll As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnuContextRefresh As ToolStripMenuItem
End Class
