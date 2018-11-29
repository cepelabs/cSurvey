<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLinkedSurveys
    Inherits cDockContentWindow

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLinkedSurveys))
        Me.tbMain = New System.Windows.Forms.ToolStrip()
        Me.cmdAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdUnlink = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdRefresh = New System.Windows.Forms.ToolStripButton()
        Me.tvLinkedSurveys = New BrightIdeasSoftware.ObjectListView()
        Me.colLinkedSurveysIcon = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysGPSState = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysName = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysFilename = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysFolder = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysNote = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.colLinkedSurveysLastException = CType(New BrightIdeasSoftware.OLVColumn(), BrightIdeasSoftware.OLVColumn)
        Me.mnuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuContextAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnucontextCalculate = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuContextUnlink = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnucontextRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdCalculate = New System.Windows.Forms.ToolStripDropDownButton()
        Me.cmdCalculateSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdCalculateAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbMain.SuspendLayout()
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuContext.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbMain
        '
        resources.ApplyResources(Me.tbMain, "tbMain")
        Me.tbMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tbMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdAdd, Me.ToolStripSeparator1, Me.cmdUnlink, Me.ToolStripSeparator2, Me.cmdCalculate, Me.ToolStripSeparator3, Me.cmdRefresh})
        Me.tbMain.Name = "tbMain"
        '
        'cmdAdd
        '
        Me.cmdAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdAdd.Image = Global.cSurveyPC.My.Resources.Resources.link_add
        resources.ApplyResources(Me.cmdAdd, "cmdAdd")
        Me.cmdAdd.Name = "cmdAdd"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'cmdUnlink
        '
        Me.cmdUnlink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        resources.ApplyResources(Me.cmdUnlink, "cmdUnlink")
        Me.cmdUnlink.Image = Global.cSurveyPC.My.Resources.Resources.link_delete
        Me.cmdUnlink.Name = "cmdUnlink"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'cmdRefresh
        '
        Me.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        resources.ApplyResources(Me.cmdRefresh, "cmdRefresh")
        Me.cmdRefresh.Name = "cmdRefresh"
        '
        'tvLinkedSurveys
        '
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysIcon)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysGPSState)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysName)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysFilename)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysFolder)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysNote)
        Me.tvLinkedSurveys.AllColumns.Add(Me.colLinkedSurveysLastException)
        Me.tvLinkedSurveys.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvLinkedSurveys.CellEditUseWholeCell = False
        Me.tvLinkedSurveys.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colLinkedSurveysIcon, Me.colLinkedSurveysGPSState, Me.colLinkedSurveysName, Me.colLinkedSurveysFilename, Me.colLinkedSurveysFolder, Me.colLinkedSurveysNote, Me.colLinkedSurveysLastException})
        Me.tvLinkedSurveys.ContextMenuStrip = Me.mnuContext
        Me.tvLinkedSurveys.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.tvLinkedSurveys, "tvLinkedSurveys")
        Me.tvLinkedSurveys.FullRowSelect = True
        Me.tvLinkedSurveys.HideSelection = False
        Me.tvLinkedSurveys.MultiSelect = False
        Me.tvLinkedSurveys.Name = "tvLinkedSurveys"
        Me.tvLinkedSurveys.ShowGroups = False
        Me.tvLinkedSurveys.UseCompatibleStateImageBehavior = False
        Me.tvLinkedSurveys.View = System.Windows.Forms.View.Details
        Me.tvLinkedSurveys.VirtualMode = True
        '
        'colLinkedSurveysIcon
        '
        Me.colLinkedSurveysIcon.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysIcon, "colLinkedSurveysIcon")
        '
        'colLinkedSurveysGPSState
        '
        Me.colLinkedSurveysGPSState.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysGPSState, "colLinkedSurveysGPSState")
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
        'colLinkedSurveysFolder
        '
        Me.colLinkedSurveysFolder.IsEditable = False
        resources.ApplyResources(Me.colLinkedSurveysFolder, "colLinkedSurveysFolder")
        '
        'colLinkedSurveysNote
        '
        resources.ApplyResources(Me.colLinkedSurveysNote, "colLinkedSurveysNote")
        '
        'colLinkedSurveysLastException
        '
        resources.ApplyResources(Me.colLinkedSurveysLastException, "colLinkedSurveysLastException")
        '
        'mnuContext
        '
        resources.ApplyResources(Me.mnuContext, "mnuContext")
        Me.mnuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuContextAdd, Me.ToolStripMenuItem2, Me.mnuContextOpen, Me.mnucontextCalculate, Me.ToolStripMenuItem3, Me.mnuContextUnlink, Me.ToolStripMenuItem1, Me.mnucontextRefresh})
        Me.mnuContext.Name = "mnuContext"
        '
        'mnuContextAdd
        '
        Me.mnuContextAdd.Image = Global.cSurveyPC.My.Resources.Resources.link_add
        Me.mnuContextAdd.Name = "mnuContextAdd"
        resources.ApplyResources(Me.mnuContextAdd, "mnuContextAdd")
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        resources.ApplyResources(Me.ToolStripMenuItem2, "ToolStripMenuItem2")
        '
        'mnuContextOpen
        '
        resources.ApplyResources(Me.mnuContextOpen, "mnuContextOpen")
        Me.mnuContextOpen.Name = "mnuContextOpen"
        '
        'mnucontextCalculate
        '
        resources.ApplyResources(Me.mnucontextCalculate, "mnucontextCalculate")
        Me.mnucontextCalculate.Image = Global.cSurveyPC.My.Resources.Resources.calculator
        Me.mnucontextCalculate.Name = "mnucontextCalculate"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        resources.ApplyResources(Me.ToolStripMenuItem3, "ToolStripMenuItem3")
        '
        'mnuContextUnlink
        '
        resources.ApplyResources(Me.mnuContextUnlink, "mnuContextUnlink")
        Me.mnuContextUnlink.Image = Global.cSurveyPC.My.Resources.Resources.link_delete
        Me.mnuContextUnlink.Name = "mnuContextUnlink"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        resources.ApplyResources(Me.ToolStripMenuItem1, "ToolStripMenuItem1")
        '
        'mnucontextRefresh
        '
        Me.mnucontextRefresh.Image = Global.cSurveyPC.My.Resources.Resources.arrow_refresh
        Me.mnucontextRefresh.Name = "mnucontextRefresh"
        resources.ApplyResources(Me.mnucontextRefresh, "mnucontextRefresh")
        '
        'cmdCalculate
        '
        Me.cmdCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cmdCalculate.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdCalculateSelected, Me.cmdCalculateAll})
        Me.cmdCalculate.Image = Global.cSurveyPC.My.Resources.Resources.calculator
        resources.ApplyResources(Me.cmdCalculate, "cmdCalculate")
        Me.cmdCalculate.Name = "cmdCalculate"
        '
        'cmdCalculateSelected
        '
        Me.cmdCalculateSelected.Name = "cmdCalculateSelected"
        resources.ApplyResources(Me.cmdCalculateSelected, "cmdCalculateSelected")
        '
        'cmdCalculateAll
        '
        Me.cmdCalculateAll.Name = "cmdCalculateAll"
        resources.ApplyResources(Me.cmdCalculateAll, "cmdCalculateAll")
        '
        'frmLinkedSurveys
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.tvLinkedSurveys)
        Me.Controls.Add(Me.tbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmLinkedSurveys"
        Me.ShowIcon = False
        Me.TopMost = True
        Me.tbMain.ResumeLayout(False)
        Me.tbMain.PerformLayout()
        CType(Me.tvLinkedSurveys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuContext.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbMain As ToolStrip
    Friend WithEvents cmdAdd As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdUnlink As ToolStripButton
    Friend WithEvents colLinkedSurveysIcon As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysName As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysFilename As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysFolder As BrightIdeasSoftware.OLVColumn
    Friend WithEvents colLinkedSurveysNote As BrightIdeasSoftware.OLVColumn
    Friend WithEvents tvLinkedSurveys As BrightIdeasSoftware.ObjectListView
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdRefresh As ToolStripButton
    Friend WithEvents colLinkedSurveysGPSState As BrightIdeasSoftware.OLVColumn
    Friend WithEvents mnuContext As ContextMenuStrip
    Friend WithEvents mnuContextUnlink As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents mnucontextRefresh As ToolStripMenuItem
    Friend WithEvents mnuContextAdd As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripSeparator
    Friend WithEvents mnucontextCalculate As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripSeparator
    Friend WithEvents mnuContextOpen As ToolStripMenuItem
    Friend WithEvents colLinkedSurveysLastException As BrightIdeasSoftware.OLVColumn
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents cmdCalculate As ToolStripDropDownButton
    Friend WithEvents cmdCalculateSelected As ToolStripMenuItem
    Friend WithEvents cmdCalculateAll As ToolStripMenuItem
End Class
